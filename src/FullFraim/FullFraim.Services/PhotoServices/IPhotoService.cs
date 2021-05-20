using FullFraim.Models.Dto_s.Photos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullFraim.Services.PhotoServices
{
    public interface IPhotoService
    {
        Task<ICollection<PhotoModel>> GetAllAsync();
        Task<PhotoModel> GetByIdAsync(int id);
        Task<PhotoModel> CreateAsync(PhotoModel model);
        Task<PhotoModel> UpdateAsync(PhotoModel model);
        Task DeleteAsync(PhotoModel model);
    }
}
