using FullFraim.Data;
using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Reviews;
using FullFraim.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using Shared;
using Shared.AllConstants;
using System;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mapper;

namespace FullFraim.Services.JuryServices
{
    public class JuryService : IJuryService
    {
        private readonly FullFraimDbContext context;

        public JuryService(FullFraimDbContext context)
        {
            this.context = context;
        }

        public async Task<OutputGiveReviewDto> GiveReviewAsync(InputGiveReviewDto inputModel)
        {
            if(inputModel == null)
            {
                throw new NullModelException(string.Format(LogMessages.NullModel, "JuryService", "GiveReviewAsync"));
            }

            var toAddReview = new PhotoReview()
            {
                Comment = inputModel.Comment,
                Score = inputModel.Score,
                Checkbox = inputModel.Checkbox,
                PhotoId = inputModel.PhotoId,
                JuryContestId = inputModel.JuryId
            };

            if (toAddReview.Checkbox == true)
            {
                toAddReview.Score = 0;
                toAddReview.Comment = Constants.Others.WrongCategory;
            }

            await this.context.PhotoReviews.AddAsync(toAddReview);
            await this.context.SaveChangesAsync();

            var contestId = (await this.context.Photos.Select(p => new { id = p.Id, contestId = p.ContestId })
                    .FirstOrDefaultAsync(c => c.id == inputModel.PhotoId)).contestId;

            return toAddReview.MapToOutputGiveReviewDto(contestId);
        }

        public async Task<ReviewDto> GetReviewAsync(int juryId, int photoId)
        {
            return await this.context.PhotoReviews
                .Where(pr => pr.PhotoId == photoId && pr.JuryContest.UserId == juryId)
                .MapToDto().FirstOrDefaultAsync();
        }

        public async Task<bool> IsJuryGivenReviewForPhotoAsync(int photoId, int juryId)
        {
            return await this.context.PhotoReviews.AnyAsync(pr => pr.PhotoId == photoId && pr.JuryContest.UserId == juryId);
        }

        public async Task<bool> IsContestInPhaseTwoAsync(int photoId)
        {
            return await this.context.Contests
                    .Where(c => c.ContestPhases.Any(cp => cp.Phase.Name == Constants.Phases.PhaseII &&
                        cp.EndDate > DateTime.UtcNow && cp.StartDate < DateTime.UtcNow))
                            .AnyAsync(c => c.Photos.Any(p => p.Id == photoId));
        }

        public async Task<bool> HasJuryAlreadyGivenReviewAsync(int juryId, int photoId)
        {
            return await this.context.JuryContests
                .AnyAsync(jc => jc.UserId == juryId 
                    && jc.PhotoReviews.Any(pr => pr.PhotoId == photoId));
        }

        public async Task<bool> IsUserJuryForContest(int contestId, int juryId)
        {
            return await this.context.JuryContests
                .Where(jc => jc.ContestId == contestId)
                    .AnyAsync(jc => jc.UserId == juryId);
        }
    }
}
