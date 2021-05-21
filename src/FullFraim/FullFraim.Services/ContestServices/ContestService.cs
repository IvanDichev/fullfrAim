using FullFraim.Data;
using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Contests;
using FullFraim.Services.Exceptions;
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

        public ContestService(FullFraimDbContext context)
        {
            this.context = context;
        }

        public async Task<OutputContestDto> CreateAsync(InputContestDto model)
        {
            if (model == null)
            {
                throw new NullModelException();
            }

            await this.AddPhasesEndTime(model);

            await this.context.Contests.AddAsync(model.MapToRaw());

            await this.context.SaveChangesAsync();

            return await AssignPhaseToDto(model.MapToDto());
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

            return await AssignPhaseToDto(result);
        }

        public async Task<OutputContestDto> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException();
            }

            var result = await this.context.Contests
                .MapToDto()
                .FirstOrDefaultAsync(CC => CC.Id == id);

            if (result == null)
            {
                throw new NotFoundException();
            }

            return await AssignPhaseToDto(result);
        }

        public async Task<OutputContestDto> UpdateAsync(int id, InputContestDto model)
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

            return await AssignPhaseToDto(model.MapToDto());
        }

        private async Task AddPhasesEndTime(InputContestDto model)
        {
            var a = Task.Run(() => this.context.ContestPhases
                .AddAsync(new ContestPhase()
                {
                    ContestId = model.Id,
                    PhaseId = 1,
                    PhaseEndDate = model.PhaseI_EndTime,
                }));

            var b = Task.Run(() => this.context.ContestPhases
                .AddAsync(new ContestPhase()
                {
                    ContestId = model.Id,
                    PhaseId = 2,
                    PhaseEndDate = model.PhaseII_EndTime,
                }));

            var c = Task.Run(() => this.context.ContestPhases
               .AddAsync(new ContestPhase()
               {
                   ContestId = model.Id,
                   PhaseId = 3,
                   PhaseEndDate = model.PhaseIII_EndTime,
               }));

            await a;
            await b;
            await c;
        }

        private async Task<OutputContestDto> AssignPhaseToDto(OutputContestDto model)
        {
            var result = await this.context.ContestPhases
                .Where(Cp => Cp.ContestId == model.Id)
                .ToListAsync();

            model.Phase = CalculatePhase
            (result[0].PhaseEndDate,
            result[1].PhaseEndDate,
            result[2].PhaseEndDate);

            return model;
        }

        private async Task<ICollection<OutputContestDto>> AssignPhaseToDto(ICollection<OutputContestDto> models)
        {
            foreach (var item in models)
            {
                var result = await this.context.ContestPhases
                    .Where(Cp => Cp.ContestId == item.Id)
                    .ToListAsync();

                item.Phase = CalculatePhase
                (result[0].PhaseEndDate,
                result[1].PhaseEndDate,
                result[2].PhaseEndDate);
            }

            return models;
        }

        private string CalculatePhase
            (DateTime phaseI,
             DateTime phaseII,
             DateTime phaseIII)
        {
            if (DateTime.UtcNow > phaseI
                && DateTime.UtcNow < phaseII)
            {
                return Constants.PhasesSeed.PhaseI;
            }

            if (DateTime.UtcNow > phaseII
                && DateTime.UtcNow < phaseIII)
            {
                return Constants.PhasesSeed.PhaseII;
            }
            else
            {
                return Constants.PhasesSeed.Finished;
            }
        }
    }
}
