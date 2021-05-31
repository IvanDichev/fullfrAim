using FullFraim.Data;
using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Contests;
using FullFraim.Models.Dto_s.Pagination;
using FullFraim.Models.Dto_s.User;
using FullFraim.Models.ViewModels.Dashboard;
using FullFraim.Services.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mapper;

namespace FullFraim.Services.ContestServices
{
    public class ContestService : IContestService
    {
        private readonly FullFraimDbContext context;
        private readonly UserManager<User> userManager;

        public ContestService(FullFraimDbContext context,
            UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<OutputContestDto> CreateAsync(InputContestDto model)
        {
            if (model == null)
            {
                throw new NullModelException($"{DateTime.UtcNow} - ContestService.CreateAsync() received null input model.");
            }

            // Extract in method to validate in controller!
            if (this.context.Contests.Any(c => c.Name == model.Name))
            {
                throw new UniqueNameException($"{DateTime.UtcNow} - ContestService.CreateAsync() input name: {model.Name} is already used. Unique name is required!");
            }

            model.Phases.StartDate_PhaseI = DateTime.UtcNow;
            model.Phases.StartDate_PhaseII = model.Phases.EndDate_PhaseI;
            model.Phases.StartDate_PhaseIII = model.Phases.EndDate_PhaseII;
            model.Phases.EndDate_PhaseIII = DateTime.MaxValue;

            var contest = await this.context.Contests.AddAsync(model.MapToRaw());

            await this.context.SaveChangesAsync();

            await AddOrganizersToJuryContest(contest.Entity.Id);

            // If contest is invitational there will be no one invited
            if (model.ContestTypeId == (await this.context.ContestTypes.FirstOrDefaultAsync(ct => ct.Name == Constants.ContestTypeSeed.Invitational)).Id)
            {
                await this.AddInvitedForTheContestAsync(model.Jury, model.Participants, contest.Entity.Id);
            }

            await this.AddContestPhasesAsync(model, contest.Entity.Id);

            await this.context.SaveChangesAsync();

            return this.context.Contests.Where(c => c.Id == contest.Entity.Id).MapToDto().FirstOrDefault();
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException($"{DateTime.UtcNow} - ContestService.DeleteAsync() received invalid Id: {id}.");
            }

            var modelToRemove = await this.context.Contests
                .FirstOrDefaultAsync(CC => CC.Id == id);

            if (modelToRemove == null)
            {
                throw new NotFoundException($"{DateTime.UtcNow} - ContestService.DeleteAsync() didn't find contest with Id: {id}.");
            }

            modelToRemove.DeletedOn = DateTime.UtcNow;
            modelToRemove.IsDeleted = true;

            await this.context.SaveChangesAsync();
        }

        public async Task<PaginatedModel<OutputContestDto>> GetAllAsync
            (int? participantId, int? juryId, string phase, string contestType, PaginationFilter paginationFilter)
        {
            var contests = this.context.Contests.AsQueryable();

            if (participantId != null || juryId != null)
            {
                contests = contests.Where(c => c.ParticipantContests.Any(pc => pc.UserId == participantId) ||
                    c.JuryContests.Any(jc => jc.UserId == juryId));
            }

            if (!string.IsNullOrEmpty(phase))
            {
                contests = contests.Where(c => c.ContestPhases.Any(cp => cp.Phase.Name == phase
                && cp.EndDate > DateTime.UtcNow && cp.StartDate < DateTime.UtcNow));
            }

            if (!string.IsNullOrEmpty(contestType))
            {
                contests = contests.Where(c => c.ContestType.Name == contestType);
            }

            var paginatedModel = new PaginatedModel<OutputContestDto>()
            {
                Model = await contests.OrderByDescending(c => c.CreatedOn)
                    .Skip(paginationFilter.PageSize * (paginationFilter.PageNumber - 1))
                    .Take(paginationFilter.PageSize)
                    .MapToDto()
                    .ToListAsync(),
                RecordsPerPage = paginationFilter.PageSize,
                TotalPages = (int)Math.Ceiling(await this.context.Contests
                    .CountAsync(p => p.Id == p.Id) / (double)paginationFilter.PageSize),
            };

            return paginatedModel;
        }

        public async Task<PaginatedModel<OutputContestDto>> GetAllForUserAsync (int userId, PaginationFilter paginationFilter)
        {
            var contests = this.context.Contests.AsQueryable();

            contests = contests.Where(c => c.ParticipantContests.Any(pc => pc.UserId == userId) ||
                c.JuryContests.Any(jc => jc.UserId == userId) || 
                    (c.ContestPhases.Any(cp => cp.Phase.Name == Constants.PhasesSeed.PhaseI
                && cp.EndDate > DateTime.UtcNow && cp.StartDate < DateTime.UtcNow) &&
                c.ContestType.Name == Constants.ContestTypeSeed.Open));

            var paginatedModel = new PaginatedModel<OutputContestDto>()
            {
                Model = await contests.OrderByDescending(c => c.CreatedOn)
                    .Skip(paginationFilter.PageSize * (paginationFilter.PageNumber - 1))
                    .Take(paginationFilter.PageSize)
                    .MapToDto()
                    .ToListAsync(),
                RecordsPerPage = paginationFilter.PageSize,
                TotalPages = (int)Math.Ceiling(await this.context.Contests
                    .CountAsync(p => p.Id == p.Id) / (double)paginationFilter.PageSize),
            };

            return paginatedModel;
        }

        public async Task<PaginatedModel<string>> GetCoversAsync(PaginationFilter paginationFilter)
        {
            var paginatedModel = new PaginatedModel<string>()
            {
                Model = await this.context.Contests.OrderByDescending(c => c.CreatedOn)
                   .Skip(paginationFilter.PageSize * (paginationFilter.PageNumber - 1))
                   .Take(paginationFilter.PageSize)
                   .MapToUrl()
                   .ToListAsync(),
                RecordsPerPage = paginationFilter.PageSize,
                TotalPages = (int)Math.Ceiling(await this.context.Contests
                   .CountAsync(p => p.Id == p.Id) / (double)paginationFilter.PageSize),
            };

            return paginatedModel;
        }

        public async Task<OutputContestDto> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException($"{DateTime.UtcNow} - ContestService.GetByIdAsync() received invalid Id: {id}.");
            }

            var result = await this.context.Contests
                .Where(c => c.Id == id)
                .MapToDto()
                .FirstOrDefaultAsync();

            if (result == null)
            {
                throw new NotFoundException($"{DateTime.UtcNow} - ContestService.GetByIdAsync() didn't find entity with Id: {id}.");
            }

            return result;
        }

        public async Task UpdateAsync(int id, InputContestDto model)
        {
            if (model == null)
            {
                throw new NullModelException($"{DateTime.UtcNow} - ContestService.UpdateAsync() received null input model.");
            }

            var dbModelToUpdate = await this.context.Contests
                .FirstOrDefaultAsync(CC => CC.Id == id);

            if (dbModelToUpdate == null)
            {
                throw new NotFoundException($"{DateTime.UtcNow} - ContestService.UpdateAsync() didn't find entity with Id: {id}.");
            }

            if (this.context.Contests.Any(c => c.Name == model.Name))
            {
                throw new UniqueNameException($"{DateTime.UtcNow} - ContestService.UpdateAsync() input name: {model.Name} is already used. Unique name is required!");
            }

            dbModelToUpdate.Name = model.Name ?? dbModelToUpdate.Name;
            dbModelToUpdate.ModifiedOn = DateTime.UtcNow;

            await this.context.SaveChangesAsync();
        }

        public async Task<ICollection<UserDto>> GetParticipantsForInvitationAsync()
        {
            var users = await userManager.GetUsersInRoleAsync(Constants.RolesSeed.User);

            var usersDto = users.MapToDto();

            return usersDto;
        }

        public async Task<ICollection<UserDto>> GetPotentialJuryForInvitationAsync()
        {
            var users = await userManager.GetUsersInRoleAsync(Constants.RolesSeed.User);

            users = users
                .Where(u => u.Points >= 150)
                .ToList();

            return users.MapToDto();
        }

        private async Task AddContestPhasesAsync(InputContestDto model, int id)
        {
            await this.context.ContestPhases
               .AddAsync(new ContestPhase()
               {
                   ContestId = id,
                   PhaseId = 1,
                   StartDate = model.Phases.StartDate_PhaseI,
                   EndDate = model.Phases.EndDate_PhaseI,
               });

            await this.context.ContestPhases
                .AddAsync(new ContestPhase()
                {
                    ContestId = id,
                    PhaseId = 2,
                    StartDate = model.Phases.StartDate_PhaseII,
                    EndDate = model.Phases.EndDate_PhaseII,
                });

            await this.context.ContestPhases
              .AddAsync(new ContestPhase()
              {
                  ContestId = id,
                  PhaseId = 3,
                  StartDate = model.Phases.StartDate_PhaseIII,
                  EndDate = model.Phases.EndDate_PhaseIII,
              });
        }

        private async Task AddOrganizersToJuryContest(int contestId)
        {
            var organisers = await userManager.GetUsersInRoleAsync(Constants.RolesSeed.Organizer);

            if (organisers.Count == 0)
            {
                throw new NoOrganizersException($"{DateTime.UtcNow} - No organizers found in database!");
            }

            foreach (var organizer in organisers)
            {
                var juryContest = new JuryContest()
                {
                    UserId = organizer.Id,
                    ContestId = contestId,
                };

                await this.context.JuryContests.AddAsync(juryContest);
            }
        }

        private async Task AddInvitedForTheContestAsync
            (ICollection<int> jury, ICollection<int> participants, int contestId)
        {
            if (participants == null || jury == null)
            {
                throw new NullModelException($"{DateTime.UtcNow} null models was passed to ContestService.AddInvitedForTheContestAsync().");
            }

            if (participants.Any(p => jury.Any(j => j == p)))
            {
                //Funny Joke :D
                throw new CheaterException($"{DateTime.UtcNow} Cannot invite participant to be jury!");
            }

            var contest = await this.context.Contests
                .FirstOrDefaultAsync(c => c.Id == contestId);

            if (contest == null)
            {
                throw new NotFoundException($"{DateTime.UtcNow} ContestService.AddInvitedForTheContestAsync() didn't find contest with id: {contestId}.");
            }

            var juryContests = jury.MapToJuryContest(contestId);
            var participantContests = participants.MapToParticipantContest(contestId);

            foreach (var juryCont in juryContests)
            {
                await this.context.JuryContests.AddAsync(juryCont);
            }

            foreach (var partCont in participantContests)
            {
                await this.context.ParticipantContests.AddAsync(partCont);
            }

            await this.context.SaveChangesAsync();
        }

        public async Task<bool> IsContestInPhaseFinished(int contestId)
        {
            if (contestId <= 0)
            {
                throw new InvalidIdException($"{DateTime.UtcNow} - ContestService.IsContestInPhaseFinished() received invalid contestId: {contestId}.");
            }

            return await this.context.Contests
                .Where(c => c.Id == contestId)
                .Where(c => c.ContestPhases.Any(cp => cp.Phase.Name == Constants.PhasesSeed.Finished &&
                    cp.StartDate < DateTime.UtcNow && cp.EndDate > DateTime.UtcNow)).AnyAsync();
        }

        public async Task<IEnumerable<DashboardViewModel>> GetContestsByCategoryAsync(int userId, int categoryId)
        {
            if (categoryId < 0)
            {
                throw new InvalidIdException($"{DateTime.UtcNow} - ContestService.GetContestsByCategoryAsync() received invalid categoryId: {categoryId}.");
            }

            var paginatedModel = await GetAllAsync(userId, userId, null, null, new PaginationFilter());

            if (categoryId != 0)
            {
                var categories = paginatedModel.Model.Where(c => c.ContestCategoryId == categoryId).ToList();
                var result = categories.Select(x => x.MapToViewDashboard());

                return result;
            }

            return paginatedModel.Model.Select(x => x.MapToViewDashboard());
        }
    }
}
