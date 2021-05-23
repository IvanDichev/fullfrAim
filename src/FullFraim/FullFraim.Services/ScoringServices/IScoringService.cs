using FullFraim.Models.Dto_s.Scorings;
using System.Threading.Tasks;

namespace FullFraim.Services.ScoringServices
{
    public interface IScoringService
    {
      //  Task GivePointsForJoiningContest(int userId, int contestId);
        Task CalculateScoring(InputScoringDto inputModel);
    }
}
