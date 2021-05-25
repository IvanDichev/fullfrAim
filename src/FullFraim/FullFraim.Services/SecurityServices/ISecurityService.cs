using System.Threading.Tasks;

namespace FullFraim.Services.SecurityServices
{
    public interface ISecurityService
    {
        Task<bool> IsUserJuryInContestAsync(int userId, int contestId);
        Task<bool> IsUserParticipantInContestAsync(int userId, int contestId);

    }
}
