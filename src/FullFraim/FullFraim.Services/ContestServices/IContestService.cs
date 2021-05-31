using FullFraim.Models.Dto_s.Contests;
using FullFraim.Models.Dto_s.User;
using System.Collections.Generic;
using FullFraim.Models.Dto_s.Pagination;
using System.Threading.Tasks;
using FullFraim.Models.ViewModels.Dashboard;

namespace FullFraim.Services.ContestServices
{
    public interface IContestService
    {
        Task<PaginatedModel<OutputContestDto>> GetAllAsync
            (int? participantId, int? juryId, string phase, string contestType, PaginationFilter paginationFilter);
        Task<OutputContestDto> GetByIdAsync(int id);
        Task<OutputContestDto> CreateAsync(InputContestDto model);
        Task UpdateAsync(int id, InputContestDto model);
        Task DeleteAsync(int id);
        Task<ICollection<UserDto>> GetParticipantsForInvitationAsync();
        Task<ICollection<UserDto>> GetPotentialJuryForInvitationAsync();
        Task<PaginatedModel<string>> GetCoversAsync(PaginationFilter paginationFilter);
        Task<bool> IsContestInPhaseFinished(int contestId);
        Task<IEnumerable<DashboardViewModel>> GetContestsByCategoryAsync(int userId, int categoryId);
        Task<PaginatedModel<OutputContestDto>> GetAllForUserAsync(int userId, PaginationFilter paginationFilter);
    }
}