using FullFraim.Data;
using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Contests;
using FullFraim.Services.Exceptions;
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

        public ContestService(FullFraimDbContext context)
        {
            this.context = context;
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
    }
}
