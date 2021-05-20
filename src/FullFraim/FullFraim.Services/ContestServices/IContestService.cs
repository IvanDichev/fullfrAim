using FullFraim.Models.Dto_s.Contests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullFraim.Services.ContestServices
{
    public interface IContestService
    {
        Task<ICollection<ContestDto>> GetAllAsync();
        Task<ContestDto> GetByIdAsync(int id);
        Task<ContestDto> CreateAsync(ContestDto model);
        Task<ContestDto> UpdateAsync(int id, ContestDto model);
        Task DeleteAsync(int id);
    }
}