using FullFraim.Data;
using FullFraim.Models.Dtos.Photo;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullFraim.Services.PhotoService
{
    public class PhotoService : IPhotoService
    {
        private readonly FullFraimDbContext context;

        public PhotoService(FullFraimDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<PhotoDto>> GetTopRecentPhotosAsync()
        {
            var photos = this.context.Photos;
                //.OrderBy(p => p.PhotoReviews) // TODO: Not working with PhotoReviews
                //.Take(5);

            var photosDto = await photos.Select(p => new PhotoDto()
            {
                Id = p.Id,
                FirstName = p.User.FirstName,
                LastName = p.User.LastName,
                PhotoName = p.Name,
                PhotoUrl = p.Url,
            }).ToListAsync();

            return photosDto;
        }
    }
}
