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

        public async Task<OutputContestCategoryModel> Create(InputContestCategoryModel model)
        {
            if(model == null)
            {
                throw new NullModelException();
            }

            var result = await this.context.ContestCategories
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

            var modelToRemove = await this.context.ContestCategories
                .FirstOrDefaultAsync(CC => CC.Id == id);

            modelToRemove.DeletedOn = DateTime.UtcNow;
            modelToRemove.IsDeleted = true;

            await this.context.SaveChangesAsync();
        }

        public async Task<ICollection<OutputContestCategoryModel>> GetAll()
        {
            var DbResult = await this.context.ContestCategories.ToListAsync();

            var result = new List<OutputContestCategoryModel>();

            foreach (var contestCategory in DbResult)
            {
                result.Add(contestCategory.MapToDto());
            }

            return result;
        }

        public async Task<OutputContestCategoryModel> GetById(int id)
        {
            if(id <= 0)
            {
                throw new InvalidIdException();
            }

            var result = await this.context.ContestCategories
                .FirstOrDefaultAsync(CC => CC.Id == id);

            if(result == null)
            {
                throw new DbModelNotFoundException();
            }

            return result.MapToDto();
        }

        public async Task<OutputContestCategoryModel> Update(int id, InputContestCategoryModel model)
        {
            if(model == null)
            {
                throw new NullModelException();
            }

            var dbModelToUpdate = await this.context.ContestCategories
                .FirstOrDefaultAsync(CC => CC.Id == id);

            if(dbModelToUpdate == null)
            {
                throw new DbModelNotFoundException();
            }

            dbModelToUpdate.Name = model.Name ?? dbModelToUpdate.Name;
            dbModelToUpdate.ModifiedOn = DateTime.UtcNow;

            return dbModelToUpdate.MapToDto();
        }
    }
}
