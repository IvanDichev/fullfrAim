using FullFraim.Data;
using FullFraim.Models.Dto_s.ContestTypes;
using FullFraim.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities.Mapper;

namespace FullFraim.Services.ContestTypeServices
{
    public class ContestTypeService : IContestTypeService
    {
        private readonly FullFraimDbContext context;

        public ContestTypeService(FullFraimDbContext context)
        {
            this.context = context;
        }

        public async Task<ContestTypeModel> CreateAsync(ContestTypeModel model)
        {
            if (model == null)
            {
                throw new NullModelException();
            }

            await this.context.ContestTypes
                .AddAsync(model.MapToRaw());

            await this.context
                .SaveChangesAsync();

            return model;
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException();
            }

            var modelToRemove = await this.context.ContestTypes
                .FirstOrDefaultAsync(CC => CC.Id == id);

            modelToRemove.DeletedOn = DateTime.UtcNow;
            modelToRemove.IsDeleted = true;

            await this.context.SaveChangesAsync();
        }

        public async Task<ICollection<ContestTypeModel>> GetAllAsync()
        {
            var result = await this.context.ContestTypes
                .MapToDto()
                .ToListAsync();

            return result;
        }

        public async Task<ContestTypeModel> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException();
            }

            var result = await this.context.ContestTypes
                .MapToDto()
                .FirstOrDefaultAsync(CC => CC.Id == id);

            if (result == null)
            {
                throw new NotFoundException();
            }

            return result;
        }

        public async Task<ContestTypeModel> UpdateAsync(int id, ContestTypeModel model)
        {
            if (model == null)
            {
                throw new NullModelException();
            }

            var dbModelToUpdate = await this.context.ContestTypes
                .FirstOrDefaultAsync(CC => CC.Id == id);

            if (dbModelToUpdate == null)
            {
                throw new NotFoundException();
            }

            dbModelToUpdate.Name = model.Name ?? dbModelToUpdate.Name;
            dbModelToUpdate.ModifiedOn = DateTime.UtcNow;

            await this.context.SaveChangesAsync();

            return model;
        }
    }
}
