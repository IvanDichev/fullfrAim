﻿using FullFraim.Models.Dto_s.Contests;
using FullFraim.Models.Dto_s.Pagination;
using System.Threading.Tasks;

namespace FullFraim.Services.ContestServices
{
    public interface IContestService
    {
        Task<PaginatedModel<OutputContestDto>> GetAllAsync
            (int? participantId, int? juryId, string phase, string contestType, PaginationFilter paginationFilter);
        Task<OutputContestDto> GetByIdAsync(int id);
        Task<OutputContestDto> CreateAsync(InputContestDto model);
        Task UpdateAsync(int id, InputContestDto model);
        Task DeleteAsync(int id);
        Task<PaginatedModel<string>> GetCoversAsync(PaginationFilter paginationFilter);
        Task<bool> IsContestInPhaseFinished(int contestId);
    }
}