using FullFraim.Models.Dto_s.Contests;
using FullFraim.Models.Dto_s.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullFraim.Services.ContestServices
{
    public interface IContestService
    {
        Task<PaginatedModel<OutputContestDto>> GetAllAsync(int userId, PaginationFilter paginationFilter);
        Task<OutputContestDto> GetByIdAsync(int id);
        Task CreateAsync(InputContestDto model);
        Task UpdateAsync(int id, InputContestDto model);
        Task DeleteAsync(int id);
        Task<PaginatedModel<string>> GetCoversAsync(PaginationFilter paginationFilter);
        Task<ICollection<OutputContestDto>> GetContestsInPhaseOneAsync(int userId);
        Task<ICollection<OutputContestDto>> GetContestsInPhaseTwoAsync(int userId);
        Task<ICollection<OutputContestDto>> GetContestsInPhaseFinishedAsync(int userId);
    }
}