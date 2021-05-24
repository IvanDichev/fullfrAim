using System.Threading.Tasks;

namespace FullFraim.Services.SecurityServices
{
    public interface ISecurityService
    {
        Task<bool> IsUserJuryInContest(int userId, int contestId);

    }
}
