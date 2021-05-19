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
        public Task<OutputPhotoModel> CreateAsync(InputPhotoModel model)
        {
            if (model == null)
            {
                throw new NullModelException();
            }

        }

        public Task DeleteAsync(InputPhotoModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<OutputPhotoModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OutputPhotoModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OutputPhotoModel> UpdateAsync(InputPhotoModel model)
        {
            throw new NotImplementedException();
        }
    }
}
