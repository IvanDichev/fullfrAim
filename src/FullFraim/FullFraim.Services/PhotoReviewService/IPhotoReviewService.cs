using FullFraim.Models.Dto_s.PhotoReview;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullFraim.Services.PhotoReviewService
{
    public interface IPhotoReviewService
    {
        Task<ICollection<PhotoReviewModel>> GetAllAsync();
        Task<PhotoReviewModel> GetByIdAsync(int id);
        Task<PhotoReviewModel> CreateAsync(PhotoReviewModel model);
        Task<PhotoReviewModel> UpdateAsync(int id, PhotoReviewModel model);
        Task DeleteAsync(int id);
    }
}
