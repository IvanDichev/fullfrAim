using FullFraim.Models.Dto_s.Contests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullFraim.Services.ContestServices
{
    public interface IContestService
    {
        Task<ICollection<OutputContestDto>> GetAllAsync();
        Task<OutputContestDto> GetByIdAsync(int id);
        Task CreateAsync(InputContestDto model);
        Task UpdateAsync(int id, InputContestDto model);
        Task DeleteAsync(int id);
        Task<ICollection<string>> GetCoversAsync();
    }
}