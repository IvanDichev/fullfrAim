﻿using FullFraim.Models.Dto_s.Pagination;
using FullFraim.Models.Dto_s.Photos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullFraim.Services.PhotoService
{
    public interface IPhotoService
    {
        Task<PhotoDto> GetByIdAsync(int photoId);
        Task<PaginatedModel<PhotoDto>> GetPhotosForContestAsync
            (int userid, int contestId, PaginationFilter paginationFilter);
        Task<ICollection<PhotoDto>> GetTopRecentPhotosAsync();
        Task<bool> IsPhotoSubmitedByUserAsync(int userId, int photoId);
        Task<PaginatedModel<ContestSubmissionOutputDto>> GetDetailedSubmissionsFromContest
            (int contestId, PaginationFilter paginationFilter);
        Task<PhotoDto> GetUserSubmissionForContestAsync(int userid, int contestId);
    }
}
