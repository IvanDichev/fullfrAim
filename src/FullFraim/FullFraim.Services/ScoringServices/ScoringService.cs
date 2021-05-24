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

        public async Task AwardWinners(int userId, int contestId) // TODO: Check if no participants!!!
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

            CalculateWinnersPoints(prizeWinnerDict, "firstWinners", "secondWinners", "thirdWinners", topThreeScores);

            await this.context.SaveChangesAsync();
        }

        private void CalculateWinnersPoints(Dictionary<string, List<InputScoringDto>> prizeWinnerDict, string first, string second, string third, List<double> topThreeScores)
        {
            if (prizeWinnerDict[first].Count == 1)
            {
                var firstWinner = this.context.ParticipantContests.First(pc => pc.UserId == prizeWinnerDict[first][0].UserId);
                firstWinner.User.Points += 50;

                if (FirstScoreDoublesTheSecond(topThreeScores))
                {
                    firstWinner.User.Points += 25;
                }
            }
            else
            {
                for (int i = 0; i < prizeWinnerDict[first].Count; i++)
                {
                    var firstWinner = this.context.ParticipantContests.First(pc => pc.UserId == prizeWinnerDict[first][i].UserId);

                    firstWinner.User.Points += 40;
                }
            }

            if (prizeWinnerDict[second].Count == 1) // Check if empty
            {
                var secondWinner = this.context.ParticipantContests.First(pc => pc.UserId == prizeWinnerDict[second][0].UserId);
                secondWinner.User.Points += 35;
            }
            else
            {
                for (int i = 0; i < prizeWinnerDict[second].Count; i++)
                {
                    var secondWinner = this.context.ParticipantContests.First(pc => pc.UserId == prizeWinnerDict[second][i].UserId);
                    secondWinner.User.Points += 25;
                }
            }

            if (prizeWinnerDict[third].Count == 1) // Check if empty
            {
                var thirdWinner = this.context.ParticipantContests.First(pc => pc.UserId == prizeWinnerDict[third][0].UserId);
                thirdWinner.User.Points += 20;
            }
            else
            {
                for (int i = 0; i < prizeWinnerDict[third].Count; i++)
                {
                    var thirdWinner = this.context.ParticipantContests.First(pc => pc.UserId == prizeWinnerDict[third][i].UserId);
                    thirdWinner.User.Points += 10;
                }
            }
        }

        private bool FirstScoreDoublesTheSecond(List<double> topThreeScores)
        {
            if (topThreeScores[0] >= 2 * topThreeScores[1])
            {
                return true;
            }

            return false;
        }

        private double CalculateUserScore(int userId, int contestId)
        {
            var userReviews = this.context.PhotoReviews
                .Where(pr => pr.Photo.Participant.UserId == userId &&
                pr.Photo.Participant.ContestId == contestId);

            int userReviewsCount = userReviews.Count();

            double userFinalScore; 

            if (userReviewsCount > 0)
            {
                var userScoreSum = userReviews.Sum(pr => pr.Score);
                userFinalScore = userScoreSum / userReviewsCount;
            }
            else
            {
                userFinalScore = 3;         // If a photo is not reviewed, a default score of 3 is awarded
            }

            return userFinalScore;
        }
    }
}
