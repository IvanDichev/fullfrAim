using FullFraim.Data;
using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Contests;
using FullFraim.Models.Dto_s.PhotoJunkies;
using FullFraim.Services.Exceptions;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<User> userManager;

        public PhotoJunkieService(FullFraimDbContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        // TODO: Display current points and ranking and how much until next ranking at a visible place 

        public async Task<ICollection<OutputContestDto>> GetContestsAsync(int userId) // TODO: Wrong, fix it!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // All contests that are open or junkie currently participates or have participated
        {
            var contests = await this.context.Contests
                .Where(c => c.ParticipantContests.Any(pc => pc.UserId == userId) ||
                        (c.ContestPhases.Any(cph => cph.PhaseId == this.context.Phases
                            .FirstOrDefault(ph => ph.Name == Constants.PhasesSeed.PhaseI).Id) &&
                            c.ContestType.Name == Constants.ContestTypeSeed.Open))
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

            AddPointsToUser(toAddParticipantContest);

            await this.context.ParticipantContests.AddAsync(toAddParticipantContest);
            await this.context.SaveChangesAsync();
        }

        public async Task<ICollection<User>> GetAllAsync()
        {
            return await this.userManager.GetUsersInRoleAsync("User");
        }

        public async Task<PhotoJunkieRankDto> GetPointsTillNextRankAsync(int userId)
        {
            var user = await this.userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                throw new NotFoundException();
            }

            var junkieTillNextRankDto = new PhotoJunkieRankDto()
            {
                RankPoints = (int)user.Points,
                Rank = user.Rank.Name,
                PointsTillNextRank = TillNextRankPoints((int)user.Points),
            };

            return junkieTillNextRankDto;
        }

        private int TillNextRankPoints(int currentPoints)
        {
            if (currentPoints <= 50)
            {
                return 51 - currentPoints;
            }
            else if (currentPoints <= 150)
            {
                return 151 - currentPoints;
            }
            else if (currentPoints <= 1000)
            {
                return currentPoints - 1001;
            }

            return 0;
        }

        private static void AddPointsToUser(ParticipantContest toAddParticipantContest)
        {
            string contestType = toAddParticipantContest.Contest.ContestType.Name;

            switch (contestType)
            {
                case Constants.ContestTypeSeed.Open:
                    toAddParticipantContest.User.Points += 1;
                    break;

                case Constants.ContestTypeSeed.Invitational:
                    toAddParticipantContest.User.Points += 3;
                    break;
            }
        } 
    }
}
