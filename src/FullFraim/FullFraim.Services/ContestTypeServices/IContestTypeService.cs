using FullFraim.Models.Dto_s.ContestTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullFraim.Services.ContestTypeServices
{
    public interface IContestTypeService
    {
        Task<ICollection<ContestTypeModel>> GetAllAsync();
        Task<ContestTypeModel> GetByIdAsync(int id);
        Task<ContestTypeModel> CreateAsync(ContestTypeModel model);
        Task<ContestTypeModel> UpdateAsync(int id, ContestTypeModel model);
        Task DeleteAsync(int id);
    }
}