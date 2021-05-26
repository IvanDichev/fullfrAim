using FullFraim.Data;
using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Contests;
using FullFraim.Services.Exceptions;
using Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mapper;
using FullFraim.Models.Dto_s.Pagination;

namespace FullFraim.Services.ContestServices
{
    public class ContestService : IContestService
    {
        private readonly FullFraimDbContext context;

        public ContestService(FullFraimDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(InputContestDto model)
        {
            if (model == null)
            {
                throw new NullModelException($"{DateTime.UtcNow} - ContestService.CreateAsync() received null input model.");
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
                throw new InvalidIdException($"{DateTime.UtcNow} - ContestService.DeleteAsync() received invalid ID.");
            }

            var modelToRemove = await this.context.Contests
                .FirstOrDefaultAsync(CC => CC.Id == id);

            modelToRemove.DeletedOn = DateTime.UtcNow;
            modelToRemove.IsDeleted = true;

            await this.context.SaveChangesAsync();
        }

        public async Task<PaginatedModel<OutputContestDto>> GetAllAsync(int userId, PaginationFilter paginationFilter)
        {
            var contests = this.context.Contests
                .Where(c => c.ParticipantContests.Any(pc => pc.UserId == userId) ||
                    c.JuryContests.Any(jc => jc.UserId == userId));

            var paginatedModel = new PaginatedModel<OutputContestDto>()
            {
                Model = await contests.OrderByDescending(c => c.ContestCategoryId)
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
            var contests = this.context.Contests
                .Where(c => c.Cover_Url != null);

            var paginatedModel = new PaginatedModel<string>()
            {
                Model = await contests.OrderByDescending(c => c.ContestCategoryId)
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
                throw new InvalidIdException($"{DateTime.UtcNow} - ContestService.GrtByIdAsync() received invalid ID.");
            }

            var result = await this.context.Contests
                .Where(c => c.Id == id)
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
                throw new NullModelException($"{DateTime.UtcNow} - ContestService.UpdateAsync() received null input model.");
            }

            var dbModelToUpdate = await this.context.Contests
                .FirstOrDefaultAsync(CC => CC.Id == id);

            if (dbModelToUpdate == null)
            {
                throw new NotFoundException($"{DateTime.UtcNow} - ContestService.UpdateAsync() the model to update was not found.");
            }

            dbModelToUpdate.Name = model.Name ?? dbModelToUpdate.Name;
            dbModelToUpdate.ModifiedOn = DateTime.UtcNow;

            await this.context.SaveChangesAsync();
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
                }); ;

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

        public async Task<PaginatedModel<OutputContestDto>> GetContestsInPhaseOneAsync(int userId, PaginationFilter paginationFilter)
        {
            var contestsInPhaseOne = this.context.Contests
                .Where(c => c.ContestPhases.Any(cph => cph.Phase.Name == Constants.PhasesSeed.PhaseI) &&
                    c.ParticipantContests.Any(pc => pc.UserId == userId) ||
                    c.JuryContests.Any(jc => jc.UserId == userId));

            return new PaginatedModel<OutputContestDto>()
            {
                Model = await contestsInPhaseOne
                .OrderByDescending(c => c.ContestCategoryId)
                    .Skip(paginationFilter.PageSize * (paginationFilter.PageNumber - 1))
                    .Take(paginationFilter.PageSize)
                    .MapToDto()
                    .ToListAsync(),
                RecordsPerPage = paginationFilter.PageSize,
                TotalPages = (int)Math.Ceiling(await this.context.Contests
                    .CountAsync(p => p.Id == p.Id) / (double)paginationFilter.PageSize),
            };
        }

        public async Task<PaginatedModel<OutputContestDto>> GetContestsInPhaseTwoAsync(int userId, PaginationFilter paginationFilter) 
        {
            var contestsInPhaseTwo = this.context.Contests
                .Where(c => c.ContestPhases.Any(cph => cph.Phase.Name == Constants.PhasesSeed.PhaseII) &&
                    c.ParticipantContests.Any(pc => pc.UserId == userId) ||
                    c.JuryContests.Any(jc => jc.UserId == userId));

            return new PaginatedModel<OutputContestDto>()
            {
                Model = await contestsInPhaseTwo
                .OrderByDescending(c => c.ContestCategoryId)
                    .Skip(paginationFilter.PageSize * (paginationFilter.PageNumber - 1))
                    .Take(paginationFilter.PageSize)
                    .MapToDto()
                    .ToListAsync(),
                RecordsPerPage = paginationFilter.PageSize,
                TotalPages = (int)Math.Ceiling(await this.context.Contests
                    .CountAsync(p => p.Id == p.Id) / (double)paginationFilter.PageSize),
            };
        }

        public async Task<PaginatedModel<OutputContestDto>> GetContestsInPhaseFinishedAsync(int userId, PaginationFilter paginationFilter) 
        {
            var contestsInPhaseFinished = this.context.Contests
               .Where(c => c.ContestPhases.Any(cph => cph.Phase.Name == Constants.PhasesSeed.Finished) &&
                   c.ParticipantContests.Any(pc => pc.UserId == userId) ||
                   c.JuryContests.Any(jc => jc.UserId == userId));

            return new PaginatedModel<OutputContestDto>()
            {
                Model = await contestsInPhaseFinished
                .OrderByDescending(c => c.ContestCategoryId)
                    .Skip(paginationFilter.PageSize * (paginationFilter.PageNumber - 1))
                    .Take(paginationFilter.PageSize)
                    .MapToDto()
                    .ToListAsync(),
                RecordsPerPage = paginationFilter.PageSize,
                TotalPages = (int)Math.Ceiling(await this.context.Contests
                    .CountAsync(p => p.Id == p.Id) / (double)paginationFilter.PageSize),
            };
        }
    }
}
