using FullFraim.Models.Dto_s.Contests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullFraim.Services.ContestServices
{
    public interface IContestService
    {
        Task<ICollection<ContestModel>> GetAllAsync();
        Task<ContestModel> GetByIdAsync(int id);
        Task<ContestModel> CreateAsync(ContestModel model);
        Task<ContestModel> UpdateAsync(int id, ContestModel model);
        Task DeleteAsync(int id);
    }
}