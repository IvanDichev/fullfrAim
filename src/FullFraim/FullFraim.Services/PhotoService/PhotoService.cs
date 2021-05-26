using FullFraim.Data;
using FullFraim.Models.Dto_s.Pagination;
using FullFraim.Models.Dto_s.Photos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mapper;

namespace FullFraim.Services.PhotoService
{
    public class PhotoService : IPhotoService
    {
        private readonly FullFraimDbContext context;

        public PhotoService(FullFraimDbContext context)
        {
            this.context = context;
        }

        public async Task<PhotoDto> GetByIdAsync(int photoId)
        {
            var photo = await this.context.Photos
                .MapToDto()
                .FirstOrDefaultAsync(p => p.Id == photoId);

            return photo; 
        }

        public async Task<bool> IsPhotoSubmitedByUserAsync(int userId, int photoId)
        {
            var isPhotoSubmitedbyUser = this.context.Photos
                .Any(p => p.Id == photoId && p.Participant.UserId == userId);

            return isPhotoSubmitedbyUser;
        }

        public async Task<PaginatedModel<PhotoDto>> GetPhotosForContestAsync(int contestId, PaginationFilter paginationFilter)
        {
            var photos = this.context.Photos
                .Where(p => p.Contest.Id == contestId);

            var paginatedModel = new PaginatedModel<PhotoDto>()
            {
                Model = await photos.OrderByDescending(p => p.CreatedOn)
                    .Skip(paginationFilter.PageSize * (paginationFilter.PageNumber - 1))
                    .Take(paginationFilter.PageSize)
                    .MapToDto()
                    .ToListAsync(),
                RecordsPerPage = paginationFilter.PageSize,
                TotalPages = (int)Math.Ceiling(await this.context.Photos
                    .CountAsync(p => p.Id == p.Id) / (double)paginationFilter.PageSize),
            };

            return paginatedModel;
        }

        public async Task<ICollection<PhotoDto>> GetTopRecentPhotos()
        {
            var TopTenPhotos = await this.context.Photos
                .Where(p => p.Contest.ContestPhases.Where(cp => cp.Phase.Name == "Finished")
                    .Any(cp => cp.StartDate < DateTime.UtcNow))
                .OrderByDescending(p => p.Contest.CreatedOn)
                .OrderByDescending(p => p.PhotoReviews.Sum(pr => pr.Score) / p.PhotoReviews.Count)
                .Take(10)
                .MapToDto()
                .ToListAsync();

            return TopTenPhotos;
        }
    }
}
