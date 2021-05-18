using FullFraim.Models.Dto_s.ContestCategories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullFraim.Services.ContestCatgeoryServices
{
    public interface IContestCategoryService
    {
        Task<ICollection<OutputContestCategoryModel>> GetAll();
        Task<OutputContestCategoryModel> GetById(int id);
        Task<OutputContestCategoryModel> Create(InputContestCategoryModel model);
        Task<OutputContestCategoryModel> Update(InputContestCategoryModel model);
        Task Delete(InputContestCategoryModel model);
    }
}