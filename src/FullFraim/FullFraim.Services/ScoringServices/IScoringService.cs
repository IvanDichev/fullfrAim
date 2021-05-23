using FullFraim.Models.Dto_s.Scorings;
using System.Threading.Tasks;

namespace FullFraim.Services.ScoringServices
{
    public interface IScoringService
    {
        Task SelectWinners(int userId, int contestId);
    }
}
