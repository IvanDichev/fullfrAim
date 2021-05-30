using System.Threading.Tasks;

namespace FullFraim.Services.ScoringServices
{
    public interface IScoringService
    {
        Task AwardWinners(int userId, int contestId);
    }
}
