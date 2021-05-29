using FullFraim.Models.Dto_s.Reviews;
using System.Threading.Tasks;

namespace FullFraim.Services.JuryServices
{
    public interface IJuryService
    {
        Task<OutputGiveReviewDto> GiveReviewAsync(InputGiveReviewDto inputModel);
        Task<bool> IsContestInPhaseTwoAsync(int photoId);
        Task<bool> HasJuryAlreadyGivenReviewAsync(int juryId, int photoId);
    }
}
