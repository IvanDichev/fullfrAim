using FullFraim.Data;
using FullFraim.Data.Models;
using FullFraim.Services.ScoringServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using Utilities.TestingUtils;

namespace FullFraim.Tests.ScoringTests
{
    [TestClass]
    public class ScoringServiceTests
    {
        [TestMethod]
        [DataRow(0, 0)]
        [DataRow(1, 1)]
        [DataRow(2, 2)]
        [DataRow(3, 3)]
        [DataRow(10, 10)]
        public async Task AwardWinnersAsync_ShouldUpdateWinnersPointsInDatabase_WhenThereAreOnlyTwoWinnersWithSameScore(int scoreOne, int scoreTwo)
        {
            //Arrange
            var options = TestUtils
                .GetInMemoryDatabaseOptions<FullFraimDbContext>
                (nameof(AwardWinnersAsync_ShouldUpdateWinnersPointsInDatabase_WhenThereAreOnlyTwoWinnersWithSameScore));

            using (var arrangeContext  = new FullFraimDbContext(options))
            {
                arrangeContext.PhotoReviews.Add(new PhotoReview() // userId 2
                {
                    Score = (uint)scoreOne,
                    PhotoId = 1,
                });

                arrangeContext.PhotoReviews.Add(new PhotoReview() // userId 3
                {
                    Score = (uint)scoreTwo,
                    PhotoId = 2,
                });

                arrangeContext.Photos.AddRange(TestUtils.GetPhotos());
                arrangeContext.ParticipantContests.AddRange(TestUtils.GetParticipantContests());
                arrangeContext.Contests.AddRange(TestUtils.GetContests());
                arrangeContext.Users.AddRange(TestUtils.GetUsers());

                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FullFraimDbContext(options))
            {
                var sut = new ScoringService(assertContext);
                // Act
                await sut.AwardWinnersAsync(3);
                
                // Assert
                var firstUserPoints = assertContext.Users.FirstOrDefault(u => u.Id == 2).Points;
                var secondUserPoints = assertContext.Users.FirstOrDefault(u => u.Id == 3).Points;
                Assert.AreEqual((uint)40, firstUserPoints);
                Assert.AreEqual((uint)40, secondUserPoints);

                await assertContext.Database.EnsureDeletedAsync();
            }
        }

        [TestMethod]
        public async Task AwardWinnersAsync_ShouldUpdateWinnersPointsInDatabase_WhenThereAreOnlyTwoWinnersWithDifferentReviewsCount()
        {
            //Arrange
            var options = TestUtils
                .GetInMemoryDatabaseOptions<FullFraimDbContext>
                (nameof(AwardWinnersAsync_ShouldUpdateWinnersPointsInDatabase_WhenThereAreOnlyTwoWinnersWithDifferentReviewsCount));

            using (var arrangeContext = new FullFraimDbContext(options))
            {
                arrangeContext.PhotoReviews.Add(new PhotoReview() 
                {
                    Score = (uint)1,
                    PhotoId = 1,
                });

                arrangeContext.PhotoReviews.Add(new PhotoReview() 
                {
                    Score = (uint)1,
                    PhotoId = 1,
                });

                arrangeContext.PhotoReviews.Add(new PhotoReview() 
                {
                    Score = (uint)2,
                    PhotoId = 2,
                });

                arrangeContext.Photos.AddRange(TestUtils.GetPhotos());
                arrangeContext.ParticipantContests.AddRange(TestUtils.GetParticipantContests());
                arrangeContext.Contests.AddRange(TestUtils.GetContests());
                arrangeContext.Users.AddRange(TestUtils.GetUsers());

                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FullFraimDbContext(options))
            {
                var sut = new ScoringService(assertContext);
                // Act
                await sut.AwardWinnersAsync(3);

                // Assert
                int firstUserPoints = (int)assertContext.Users.FirstOrDefault(u => u.Id == 2).Points;
                int secondUserPoints = (int)assertContext.Users.FirstOrDefault(u => u.Id == 3).Points;
                Assert.AreEqual(40, firstUserPoints);
                Assert.AreEqual(40, secondUserPoints);

                await assertContext.Database.EnsureDeletedAsync();
            }
        }

        [TestMethod]
        public async Task AwardWinnersAsync_ShouldUpdateWinnersPointsInDatabase_WhenThereAreTwoWinnersWithSameReviewsCountWithDifferentScoreAndSameFinalScore()
        {
            //Arrange
            var options = TestUtils
                .GetInMemoryDatabaseOptions<FullFraimDbContext>
                (nameof(AwardWinnersAsync_ShouldUpdateWinnersPointsInDatabase_WhenThereAreTwoWinnersWithSameReviewsCountWithDifferentScoreAndSameFinalScore));

            using (var arrangeContext = new FullFraimDbContext(options))
            {
                arrangeContext.PhotoReviews.Add(new PhotoReview() // 1
                {
                    Score = (uint)3,
                    PhotoId = 1,
                });

                arrangeContext.PhotoReviews.Add(new PhotoReview() // 1
                {
                    Score = (uint)4,
                    PhotoId = 1,
                });

                arrangeContext.PhotoReviews.Add(new PhotoReview() // 2
                {
                    Score = (uint)2,
                    PhotoId = 2,
                });

                arrangeContext.PhotoReviews.Add(new PhotoReview() // 2
                {
                    Score = (uint)5,
                    PhotoId = 2,
                });

                arrangeContext.Photos.AddRange(TestUtils.GetPhotos());
                arrangeContext.ParticipantContests.AddRange(TestUtils.GetParticipantContests());
                arrangeContext.Contests.AddRange(TestUtils.GetContests());
                arrangeContext.Users.AddRange(TestUtils.GetUsers());

                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new FullFraimDbContext(options))
            {
                var sut = new ScoringService(assertContext);
                // Act
                await sut.AwardWinnersAsync(3);

                // Assert
                int firstUserPoints = (int)assertContext.Users.FirstOrDefault(u => u.Id == 2).Points;
                int secondUserPoints = (int)assertContext.Users.FirstOrDefault(u => u.Id == 3).Points;
                Assert.AreEqual(40, firstUserPoints);
                Assert.AreEqual(40, secondUserPoints);

                await assertContext.Database.EnsureDeletedAsync();
            }
        }
    }
}
