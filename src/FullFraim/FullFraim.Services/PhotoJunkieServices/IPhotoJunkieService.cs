using FullFraim.Models.Dto_s.Contests;
using FullFraim.Models.Dto_s.PhotoJunkies;
using FullFraim.Models.Dto_s.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullFraim.Services.PhotoJunkieServices
{
    public interface IPhotoJunkieService
    {
        Task EnrollForContestAsync(InputEnrollForContestDto inputModel);
        Task<ICollection<PhotoJunkieDto>> GetAllAsync();
        Task<PhotoJunkieRankDto> GetPointsTillNextRankAsync(int userId);
        Task<bool> CanJunkyEnroll(int contestId, int userId);
    }
}
