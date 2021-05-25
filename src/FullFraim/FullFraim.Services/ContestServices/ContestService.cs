using FullFraim.Data;
using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Contests;
using FullFraim.Models.Dto_s.User;
using FullFraim.Services.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public async Task CreateAsync(InputContestDto model)
        {
            if (model == null)
            {
                throw new NullModelException();
            }

            model.Phases.StartDate_PhaseI = DateTime.UtcNow;
            model.Phases.StartDate_PhaseII = model.Phases.EndDate_PhaseI;
            model.Phases.StartDate_PhaseIII = model.Phases.EndDate_PhaseII;
            model.Phases.EndDate_PhaseIII = DateTime.MaxValue;

            var contest = await this.context.Contests.AddAsync(model.MapToRaw());

            await this.context.SaveChangesAsync();

            await this.AddContestPhasesAsync(model, contest.Entity.Id);

            await this.context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException();
            }

            var modelToRemove = await this.context.Contests
                .FirstOrDefaultAsync(CC => CC.Id == id);

            modelToRemove.DeletedOn = DateTime.UtcNow;
            modelToRemove.IsDeleted = true;

            await this.context.SaveChangesAsync();
        }

        public async Task<ICollection<OutputContestDto>> GetAllAsync()
        {
            var result = await this.context.Contests
                .MapToDto()
                .ToListAsync();

            return result;
        }

        public async Task<ICollection<string>> GetCoversAsync()
        {
            var result = await this.context.Contests
                .MapToUrl()
                .ToListAsync();

            return result;
        }

        public async Task<OutputContestDto> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException();
            }

            var result = await this.context.Contests
                .Where(C => C.Id == id)
                .MapToDto()
                .FirstOrDefaultAsync();

            if (result == null)
            {
                throw new NotFoundException();
            }

            return result;
        }

        public async Task UpdateAsync(int id, InputContestDto model)
        {
            if (model == null)
            {
                throw new NullModelException();
            }

            var dbModelToUpdate = await this.context.Contests
                .FirstOrDefaultAsync(CC => CC.Id == id);

            if (dbModelToUpdate == null)
            {
                throw new NotFoundException();
            }

            dbModelToUpdate.Name = model.Name ?? dbModelToUpdate.Name;
            dbModelToUpdate.ModifiedOn = DateTime.UtcNow;

            await this.context.SaveChangesAsync();
        }

        private async Task AddContestPhasesAsync(InputContestDto model, int id)
        {
            var a = Task.Run(() => this.context.ContestPhases
               .AddAsync(new ContestPhase()
               {
                   ContestId = id,
                   PhaseId = 1,
                   StartDate = model.Phases.StartDate_PhaseI,
                   EndDate = model.Phases.EndDate_PhaseI,
               }));

            var b = Task.Run(() => this.context.ContestPhases
                .AddAsync(new ContestPhase()
                {
                    ContestId = id,
                    PhaseId = 2,
                    StartDate = model.Phases.StartDate_PhaseII,
                    EndDate = model.Phases.EndDate_PhaseII,
                }));

            var c = Task.Run(() => this.context.ContestPhases
              .AddAsync(new ContestPhase()
              {
                  ContestId = id,
                  PhaseId = 3,
                  StartDate = model.Phases.StartDate_PhaseIII,
                  EndDate = model.Phases.EndDate_PhaseIII,
              }));

            await a;
            await b;
            await c;
        }

        public async Task<ICollection<UserDto>> GetParticipantsForInvitationAsync(int contestId)
        {
            if (contestId <= 0)
            {
                throw new InvalidIdException();
            }

            var users = await this.context.Users
                .Where(u => !u.JuryContests
                .Any(jc => jc.ContestId == contestId))
                .MapToDto()
                .ToListAsync();

            return users;
        }

        public async Task<ICollection<UserDto>> GetJuryForInvitationAsync(int contestId)
        {
            if (contestId <= 0)
            {
                throw new InvalidIdException();
            }

            var users = await this.context.Users
                .Where(u => u.Points >= 150)
                .MapToDto()
                .ToListAsync();

            return users;
        }

        public async Task AddInvitedForTheContestAsync
            (ICollection<UserDto> participants, ICollection<UserDto> jury, int contestId)
        {
            if (participants == null || jury == null)
            {
                throw new NullModelException();
            }

            if (this.context.JuryContests
                .Any(j => participants.Any(p => p.UserId == j.UserId)))
            {
                //Funny Joke :D
                throw new CheaterException();
            }

            var contest = await this.context.Contests
                .FirstOrDefaultAsync(c => c.Id == contestId);

            if (contest == null)
            {
                throw new NotFoundException();
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
    }
}
