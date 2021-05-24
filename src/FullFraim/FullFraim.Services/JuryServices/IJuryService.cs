using FullFraim.Models.Dto_s.Contests;
using FullFraim.Models.Dto_s.Juries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullFraim.Services.JuryServices
{
    public interface IJuryService
    {
        Task<ICollection<OutputContestDto>> GetContestsAsync(int userId);
        Task GiveReviewAsync(InputGiveReviewDto inputModel);
    }
}
