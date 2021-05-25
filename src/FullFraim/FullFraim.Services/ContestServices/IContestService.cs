using FullFraim.Models.Dto_s.Contests;
using FullFraim.Models.Dto_s.User;
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
        Task<ICollection<UserDto>> GetParticipantsForInvitationAsync(int contestId);
        Task<ICollection<UserDto>> GetJuryForInvitationAsync(int contestId);
        Task AddInvitedForTheContestAsync
            (ICollection<UserDto> jury, ICollection<UserDto> participants, int contestId);
    }
}