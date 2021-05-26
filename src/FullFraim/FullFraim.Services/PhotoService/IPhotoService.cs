using FullFraim.Models.Dto_s.Pagination;
using FullFraim.Models.Dto_s.Photos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullFraim.Services.PhotoService
{
    public interface IPhotoService
    {
        Task<PaginatedModel<PhotoDto>> GetPhotosForContestAsync(int contestId, PaginationFilter paginationFilter);
        Task<ICollection<PhotoDto>> GetTopRecentPhotos();
    }
}
