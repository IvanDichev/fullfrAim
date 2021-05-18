using FullFraim.Data;
using FullFraim.Models.Dto_s.Phases;
using FullFraim.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities.Mapper;

namespace FullFraim.Services.PhaseServices
{
    public class PhaseService : IPhaseService
    {
        private readonly FullFraimDbContext context;

        public PhaseService(FullFraimDbContext context)
        {
            this.context = context;
        }

        public async Task<OutputPhaseModel> Create(InputPhaseModel model)
        {
            if (model == null)
            {
                throw new NullModelException();
            }

            var result = await this.context.Phases
                .AddAsync(model.MapToRaw());

            await this.context
                .SaveChangesAsync();

            return result.Entity
                .MapToDto();
        }

        public async Task Delete(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException();
            }

            var modelToRemove = await this.context.Phases
                .FirstOrDefaultAsync(CC => CC.Id == id);

            modelToRemove.DeletedOn = DateTime.UtcNow;
            modelToRemove.IsDeleted = true;

            await this.context.SaveChangesAsync();
        }

        public async Task<ICollection<OutputPhaseModel>> GetAll()
        {
            var DbResult = await this.context.Phases.ToListAsync();

            var result = new List<OutputPhaseModel>();

            foreach (var phase in DbResult)
            {
                result.Add(phase.MapToDto());
            }

            return result;
        }

        public async Task<OutputPhaseModel> GetById(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException();
            }

            var result = await this.context.Phases
                .FirstOrDefaultAsync(CC => CC.Id == id);

            if (result == null)
            {
                throw new DbModelNotFoundException();
            }

            return result.MapToDto();
        }

        public async Task<OutputPhaseModel> Update(int id, InputPhaseModel model)
        {
            if (model == null)
            {
                throw new NullModelException();
            }

            var dbModelToUpdate = await this.context.Phases
                .FirstOrDefaultAsync(CC => CC.Id == id);

            if (dbModelToUpdate == null)
            {
                throw new DbModelNotFoundException();
            }

            dbModelToUpdate.Name = model.Name ?? dbModelToUpdate.Name;
            dbModelToUpdate.ModifiedOn = DateTime.UtcNow;

            return dbModelToUpdate.MapToDto();
        }
    }
}
