using FullFraim.Models.Dto_s.Contests;
using FullFraim.Models.Dto_s.User;
using System.Collections.Generic;
using FullFraim.Models.Dto_s.Pagination;
using System.Threading.Tasks;

namespace FullFraim.Services.ContestServices
{
    public interface IContestService
    {
        Task<PaginatedModel<OutputContestDto>> GetAllAsync(int userId, PaginationFilter paginationFilter);
        Task<OutputContestDto> GetByIdAsync(int id);
        Task<OutputContestDto> CreateAsync(InputContestDto model);
        Task UpdateAsync(int id, InputContestDto model);
        Task DeleteAsync(int id);
        Task<ICollection<UserDto>> GetParticipantsForInvitationAsync();
        Task<ICollection<UserDto>> GetPotentialJuryForInvitationAsync();
        Task<PaginatedModel<string>> GetCoversAsync(PaginationFilter paginationFilter);
        Task<PaginatedModel<OutputContestDto>> GetContestsInPhaseOneAsync(int userId, PaginationFilter paginationFilter);
        Task<PaginatedModel<OutputContestDto>> GetContestsInPhaseTwoAsync(int userId, PaginationFilter paginationFilter);
        Task<PaginatedModel<OutputContestDto>> GetContestsInPhaseFinishedAsync(int userId, PaginationFilter paginationFilter);
        Task<bool> IsContestInPhaseFinished(int contestId);
    }
}