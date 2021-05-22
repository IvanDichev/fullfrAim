using FullFraim.Data;
using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Contests;
using FullFraim.Models.Dto_s.PhotoJunkies;
using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mapper;

namespace FullFraim.Services.PhotoJunkieServices
{
    public class PhotoJunkieService : IPhotoJunkieService
    {
        private readonly FullFraimDbContext context;

        public PhotoJunkieService(FullFraimDbContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<OutputContestDto>> GetContestsAsync(int userId) 
            // All contests that are open or junkie currently participates or have participated
        {
            var contests = await this.context.Contests
                .Where(c => c.ParticipantContests
                    .Any(pc => pc.UserId == userId) || c.ContestPhases
                        .Any(cph => cph.PhaseId == this.context.Phases
                            .FirstOrDefault(ph => ph.Name == Constants.PhasesSeed.PhaseI).Id))
                .MapToDto()
                .ToListAsync();

            return contests;
        }

        public async Task EnrollForContestAsync(InputEnrollForContestDto inputModel)
        {
            var toAddParticipantContest = new ParticipantContest()
            {
                ContestId = inputModel.ContestId,
                UserId = inputModel.UserId,
                IsDeleted = false,
                CreatedOn = DateTime.UtcNow,
                Photo = new Photo()
                {
                    Title = inputModel.ImageTitle,
                    Url = inputModel.ImageUrl,
                    IsDeleted = false,
                    CreatedOn = DateTime.UtcNow,
                    // TODO ADD description
                }
            };

            await this.context.ParticipantContests.AddAsync(toAddParticipantContest);
            await this.context.SaveChangesAsync();
        }
    }
}
