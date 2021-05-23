using FullFraim.Data;
using FullFraim.Models.Dto_s.Scorings;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullFraim.Services.ScoringServices
{
    public class ScoringService : IScoringService
    {
        private readonly FullFraimDbContext context;

        public ScoringService(FullFraimDbContext context)
        {
            this.context = context;
        }

        public async Task SelectWinners(int userId, int contestId) // TODO: Check if no participants!!!
        // Once in Phase III
        {
            var currentContest = await this.context.Contests
                .Include(c => c.ParticipantContests)
                .FirstOrDefaultAsync(c => c.Id == contestId);

            var allParticipants = currentContest.ParticipantContests;

            var allParticipantsDto = new List<InputScoringDto>();

            foreach (var participant in allParticipants)
            {
                var currentParticipant = new InputScoringDto()
                {
                    UserId = participant.UserId,
                    Score = CalculateUserScore(participant.UserId, participant.ContestId)
                };

                allParticipantsDto.Add(currentParticipant);
            }

            var topThreeScores = allParticipantsDto
                .Select(p => p.Score)
                .ToHashSet()
                .OrderByDescending(p => p)
                .Take(3)
                .ToList();

            var prizeWinnerDict = new Dictionary<string, List<InputScoringDto>>
            {
                ["firstWinners"] = new List<InputScoringDto>(),
                ["firstWinners"] = allParticipantsDto.Where(p => p.Score == topThreeScores[0]).ToList(),

                ["secondWinners"] = new List<InputScoringDto>(),
                ["secondWinners"] = allParticipantsDto.Where(p => p.Score == topThreeScores[1]).ToList(),

                ["thirdWinners"] = new List<InputScoringDto>(),
                ["thirdWinners"] = allParticipantsDto.Where(p => p.Score == topThreeScores[2]).ToList(),
            };

            // Check for difference between 1st and 2nd prize scores -. use boolean to check! /Hint from Vankata/
            // Add points to users
        }

        private double CalculateUserScore(int userId, int contestId)
        {
            var userReviews = this.context.PhotoReviews
                .Where(pr => pr.Photo.Participant.UserId == userId &&
                pr.Photo.Participant.ContestId == contestId);

            int userReviewsCount = userReviews.Count();

            double userFinalScore = 0;

            if (userReviewsCount > 0)
            {
                var userScoreSum = userReviews.Sum(pr => pr.Score);
                userFinalScore = userScoreSum / userReviewsCount;
            }

            return userFinalScore;
        }
    }
}
