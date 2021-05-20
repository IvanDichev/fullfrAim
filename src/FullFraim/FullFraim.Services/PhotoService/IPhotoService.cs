using FullFraim.Models.Dtos.Photo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullFraim.Services.PhotoService
{
    public interface IPhotoService
    {
        Task<IEnumerable<PhotoDto>> GetTopRecentPhotosAsync();
    }
}
