using FullFraim.Data;
using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Contests;
using FullFraim.Models.Dto_s.PhotoJunkies;
using FullFraim.Models.Dto_s.Users;
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
        // controller
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
                    Url = inputModel.PhotoUrl,
                    IsDeleted = false,
                    Story = inputModel.ImageDescription,
                    CreatedOn = DateTime.UtcNow,
                    ContestId = inputModel.ContestId,
                }
            };

            await AddInitialPointsToUser(toAddParticipantContest);

            await this.context.ParticipantContests.AddAsync(toAddParticipantContest);
            await this.context.SaveChangesAsync();
        }

        public async Task<ICollection<PhotoJunkieDto>> GetAllAsync()
        {
            var users = await this.userManager.GetUsersInRoleAsync("User");

            return users.MapToJunkieDto().ToList();
        }

        public async Task<bool> CanJunkyEnroll(int contestId, int userId)
        {
            var isParticipant = !await this.context.ParticipantContests
                .AnyAsync(p => p.UserId == userId && p.ContestId == contestId);

            var isJury = !await this.context.JuryContests
                .AnyAsync(p => p.UserId == userId && p.ContestId == contestId);

            return isParticipant && isJury;
        }

        public async Task<PhotoJunkieRankDto> GetPointsTillNextRankAsync(int userId) // in controller
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

        private async Task AddInitialPointsToUser(ParticipantContest toAddParticipantContest)
        {
            string contestType = await this.context.Contests
                .Where(c => c.Id == toAddParticipantContest.ContestId)
                .Select(c => c.ContestType.Name)
                .FirstOrDefaultAsync();

            var userToAddPoints = await this.context.Users
                .FirstOrDefaultAsync(u => u.Id == toAddParticipantContest.UserId);

            switch (contestType)
            {
                case Constants.ContestTypeSeed.Open:
                    userToAddPoints.Points += 1;
                    break;

                case Constants.ContestTypeSeed.Invitational:
                    userToAddPoints.Points += 3;
                    break;
            }
        } 
    }
}
