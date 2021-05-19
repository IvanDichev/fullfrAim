using FullFraim.Models.Dto_s.Photos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullFraim.Services.PhotoServices
{
    public interface IPhotoService
    {
        Task<ICollection<OutputPhotoModel>> GetAll();
        Task<OutputPhotoModel> GetById(int id);
        Task<OutputPhotoModel> Create(InputPhotoModel model);
        Task<OutputPhotoModel> Update(InputPhotoModel model);
        Task Delete(InputPhotoModel model);
    }
}
