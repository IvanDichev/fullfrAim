using FullFraim.Models.Dto_s.Contests;
using FullFraim.Models.Dto_s.PhotoJunkies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullFraim.Services.PhotoJunkieServices
{
    public interface IPhotoJunkieService
    {
        Task<ICollection<OutputContestDto>> GetContestsAsync(int userId);
        Task EnrollForContestAsync(InputEnrollForContestDto inputModel);
    }
}
