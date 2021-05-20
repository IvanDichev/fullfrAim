using FullFraim.Data;
using FullFraim.Models.Dto_s.Photos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullFraim.Services.PhotoServices
{
    public class PhotoService : IPhotoService
    {
        private readonly FullFraimDbContext context;

        public PhotoService(FullFraimDbContext context)
        {
            this.context = context;
        }
        public Task<PhotoModel> CreateAsync(PhotoModel model)
        {
            if (model == null)
            {
                throw new NullModelException();
            }

        }

        public Task DeleteAsync(PhotoModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<PhotoModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PhotoModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PhotoModel> UpdateAsync(PhotoModel model)
        {
            throw new NotImplementedException();
        }
    }
}
