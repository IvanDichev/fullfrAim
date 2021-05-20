using FullFraim.Models.Dto_s.ContestCategories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullFraim.Services.ContestCatgeoryServices
{
    public interface IContestCategoryService
    {
        Task<ICollection<ContestCategoryModel>> GetAllAsync();
        Task<ContestCategoryModel> GetByIdAsync(int id);
        Task<ContestCategoryModel> CreateAsync(ContestCategoryModel model);
        Task<ContestCategoryModel> UpdateAsync(int id, ContestCategoryModel model);
        Task DeleteAsync(int id);
    }
}