using FullFraim.Data;
using FullFraim.Models.Dto_s.ContestCategories;
using FullFraim.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
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

            var result = await this.context.ContestCategories.AddAsync(model.MapToRaw());

            await this.context.SaveChangesAsync();

            return result.Entity.MapToDto();
        }

        public async Task Delete(InputContestCategoryModel model)
        {
            if (model == null)
            {
                throw new NullModelException();
            }

            this.context.ContestCategories.Remove(model.MapToRaw());

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

            }

        }

        public async Task<OutputContestCategoryModel> Update(InputContestCategoryModel model)
        {
            throw new NotImplementedException();
        }
    }
}
