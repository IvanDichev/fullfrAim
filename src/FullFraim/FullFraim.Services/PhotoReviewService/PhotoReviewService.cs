using FullFraim.Data;
using FullFraim.Models.Dto_s.PhotoReview;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullFraim.Services.PhotoReviewService
{
    public class PhotoReviewService : IPhotoReviewService
    {
        private readonly FullFraimDbContext context;

        public PhotoReviewService(FullFraimDbContext context)
        {
            this.context = context;
        }
        public Task<PhotoReviewModel> CreateAsync(PhotoReviewModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<PhotoReviewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PhotoReviewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PhotoReviewModel> UpdateAsync(int id, PhotoReviewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
