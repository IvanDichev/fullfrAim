using FullFraim.Data;
using FullFraim.Models.Dto_s.ContestCategories;
using FullFraim.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities.Mapper;

namespace FullFraim.Services.ContestCatgeoryServices
{
    public class ContestCategoryService : IContestCategoryService
    {
        private readonly FullFraimDbContext context;

        public ContestCategoryService(FullFraimDbContext context)
        {
            this.context = context;
        }

        public async Task<ContestCategoryModel> CreateAsync(ContestCategoryModel model)
        {
            if(model == null)
            {
                throw new NullModelException();
            }

            await this.context.ContestCategories
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

            var modelToRemove = await this.context.ContestCategories
                .FirstOrDefaultAsync(CC => CC.Id == id);

            modelToRemove.DeletedOn = DateTime.UtcNow;
            modelToRemove.IsDeleted = true;

            await this.context.SaveChangesAsync();
        }

        public async Task<ICollection<ContestCategoryModel>> GetAllAsync()
        {
            var result = await this.context.ContestCategories
                .MapToDto()
                .ToListAsync();

            return result;
        }

        public async Task<ContestCategoryModel> GetByIdAsync(int id)
        {
            if(id <= 0)
            {
                throw new InvalidIdException();
            }

            var result = await this.context.ContestCategories
                .MapToDto()
                .FirstOrDefaultAsync(CC => CC.Id == id);

            if(result == null)
            {
                throw new NotFoundException();
            }

            return result;
        }

        public async Task<ContestCategoryModel> UpdateAsync(int id, ContestCategoryModel model)
        {
            if(model == null)
            {
                throw new NullModelException();
            }

            var dbModelToUpdate = await this.context.ContestCategories
                .FirstOrDefaultAsync(CC => CC.Id == id);

            if(dbModelToUpdate == null)
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
