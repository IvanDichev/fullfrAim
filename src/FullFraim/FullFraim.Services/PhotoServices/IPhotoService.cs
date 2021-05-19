using FullFraim.Models.Dto_s.Photos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullFraim.Services.PhotoServices
{
    public interface IPhotoService
    {
        Task<ICollection<OutputPhotoModel>> GetAllAsync();
        Task<OutputPhotoModel> GetByIdAsync(int id);
        Task<OutputPhotoModel> CreateAsync(InputPhotoModel model);
        Task<OutputPhotoModel> UpdateAsync(InputPhotoModel model);
        Task DeleteAsync(InputPhotoModel model);
    }
}
