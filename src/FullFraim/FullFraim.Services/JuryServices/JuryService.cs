using FullFraim.Data;
using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Contests;
using FullFraim.Models.Dto_s.Juries;
using Microsoft.EntityFrameworkCore;
using Shared;
using System.Collections.Generic;
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
        public async Task<ICollection<OutputContestDto>> GetContestsAsync(int userId)
        // can see open contests and contests in which is participant or jury
        {
            var contests = await this.context.Contests
               .Where(c => c.JuryContests.Any(jc => jc.UserId == userId) ||
                       (c.ContestPhases.Any(cph => cph.PhaseId == this.context.Phases
                           .FirstOrDefault(ph => ph.Name == Constants.PhasesSeed.PhaseI).Id) &&
                           c.ContestType.Name == Constants.ContestTypeSeed.Open))
               .MapToDto()
               .ToListAsync();

            return contests;
        }

        public async Task GiveReviewAsync(InputGiveReviewDto inputModel)
        {
            // TODO: Each juror can give one review per photo
            // Check if in phaseI, otherwise can't give a review

            var toAddReview = new PhotoReview()
            {
                Comment = inputModel.Comment,
                Score = inputModel.Score,
                Checkbox = inputModel.Checkbox,
                PhotoId = inputModel.PhotoId,
                JuryContestId = inputModel.JuryId
            };

            await this.context.PhotoReviews.AddAsync(toAddReview);
            await this.context.SaveChangesAsync();
        }
    }
}
