using FullFraim.Data;
using FullFraim.Data.Models;
using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Utilities.TestingUtils
{
    public static class TestUtils
    {
        public static DbContextOptions<T> GetInMemoryDatabaseOptions<T>(string dbName)
            where T : DbContext
        {
            var options = new DbContextOptionsBuilder<T>()
                .UseInMemoryDatabase(dbName)
                .Options;

            return options;
        }

        public static ICollection<ContestCategory> GetContestCategories()
        {
            return new List<ContestCategory>()
            {
                new ContestCategory()
                {
                    Name = Constants.ConstestCategorySeed.Abstract
                },
                new ContestCategory()
                {
                    Name = Constants.ConstestCategorySeed.Architecture
                },
                new ContestCategory()
                {
                    Name = Constants.ConstestCategorySeed.Conceptual
                },
                new ContestCategory()
                {
                    Name = Constants.ConstestCategorySeed.Fashion_Beauty
                },
                new ContestCategory()
                {
                    Name = Constants.ConstestCategorySeed.Fine_Art
                },
                new ContestCategory()
                {
                    Name = Constants.ConstestCategorySeed.Landscapes
                },
                new ContestCategory()
                {
                    Name = Constants.ConstestCategorySeed.Nature
                },
                new ContestCategory()
                {
                    Name = Constants.ConstestCategorySeed.Boudoir
                },
                new ContestCategory()
                {
                    Name = Constants.ConstestCategorySeed.Photojournalism
                },
                new ContestCategory()
                {
                    Name = Constants.ConstestCategorySeed.Portrait
                },
                new ContestCategory()
                {
                    Name = Constants.ConstestCategorySeed.Street
                },
                new ContestCategory()
                {
                    Name = Constants.ConstestCategorySeed.Wildlife
                }
            };
        }
        public static ICollection<ContestPhase> GetContestPhases()
        {
            return new List<ContestPhase>()
            {
                // Contest PhaseOne
                new ContestPhase()
                {
                    ContestId = 1,
                    PhaseId = 1,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddDays(30),
                },
                new ContestPhase()
                {
                    ContestId = 1,
                    PhaseId = 2,
                    StartDate = DateTime.UtcNow.AddDays(30),
                    EndDate = DateTime.UtcNow.AddDays(60),
                },
                new ContestPhase()
                {
                    ContestId = 1,
                    PhaseId = 3,
                    StartDate = DateTime.UtcNow.AddDays(90),
                    EndDate = DateTime.MaxValue,
                },
                // Contest PhaseTwo
                new ContestPhase()
                {
                    ContestId = 2,
                    PhaseId = 1,
                    StartDate = DateTime.UtcNow.AddDays(-30),
                    EndDate = DateTime.UtcNow,
                },
                new ContestPhase()
                {
                    ContestId = 2,
                    PhaseId = 2,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddDays(30),
                },
                new ContestPhase()
                {
                    ContestId = 2,
                    PhaseId = 3,
                    StartDate = DateTime.UtcNow.AddDays(30),
                    EndDate = DateTime.MaxValue,
                },
                // Contest Finished
                new ContestPhase()
                {
                    ContestId = 3,
                    PhaseId = 1,
                    StartDate = DateTime.UtcNow.AddDays(-2),
                    EndDate = DateTime.UtcNow.AddDays(-1),
                },
                new ContestPhase()
                {
                    ContestId = 3,
                    PhaseId = 2,
                    StartDate = DateTime.UtcNow.AddDays(-1),
                    EndDate = DateTime.UtcNow,
                },
                new ContestPhase()
                {
                    ContestId = 3,
                    PhaseId = 3,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.MaxValue,
                },
                new ContestPhase()
                {
                    ContestId = 4,
                    PhaseId = 1,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddDays(30),
                },
                new ContestPhase()
                {
                    ContestId = 4,
                    PhaseId = 2,
                    StartDate = DateTime.UtcNow.AddDays(30),
                    EndDate = DateTime.UtcNow.AddDays(60),
                },
                new ContestPhase()
                {
                    ContestId = 4,
                    PhaseId = 3,
                    StartDate = DateTime.UtcNow.AddDays(60),
                    EndDate = DateTime.MaxValue,
                },
            };
        }
        public static ICollection<Contest> GetContests()
        {
            return new List<Contest>()
            {
                new Contest()
                {
                    Id = 1,
                    Name = "Portrait",
                    Description = "Portrait contest - PhaseOne",
                    Cover_Url = Constants.ImagesSeed.PortraitImgUrlCover,
                    ContestCategoryId = 10,
                    ContestTypeId = 2,
                    CreatedOn = DateTime.UtcNow,
                },
                new Contest()
                {
                    Id = 2,
                    Name = "WildlifePhaseTwo",
                    Description = "PhaseTwo",
                    Cover_Url = Constants.ImagesSeed.WildlifeImgUrlCover,
                    ContestCategoryId = 12,
                    ContestTypeId = 1,
                    CreatedOn = DateTime.UtcNow.AddDays(-30),
                },
                new Contest()
                {
                    Id = 3,
                    Name = "WildlifePhaseThree",
                    Description = "PhaseThree",
                    Cover_Url = Constants.ImagesSeed.WildlifeImgUrlCover,
                    ContestCategoryId = 12,
                    ContestTypeId = 1,
                    CreatedOn = DateTime.UtcNow.AddDays(-2),
                },
                new Contest()
                {
                    Id = 4,
                    Name = "WildlifePhaseOne",
                    Description = "PhaseOne",
                    Cover_Url = Constants.ImagesSeed.WildlifeImgUrlCover,
                    ContestCategoryId = 12,
                    ContestTypeId = 1,
                    CreatedOn = DateTime.UtcNow,
                },
            };
        }
        public static ICollection<ContestType> GetContestTypes()
        {
            return new List<ContestType>()
            {
                new ContestType()
                {
                    Name = Constants.ContestTypeSeed.Invitational
                },
                new ContestType()
                {
                   Name = Constants.ContestTypeSeed.Open
                },
            };
        }
        public static ICollection<JuryContest> GetJuryContests()
        {
            return new List<JuryContest>()
            {
                new JuryContest()
                {
                    Id = 1,
                    ContestId = 1,
                    UserId = 1,
                },
                new JuryContest()
                {
                    Id = 2,
                    ContestId = 2,
                    UserId = 1,
                },
                new JuryContest()
                {
                    Id = 3,
                    ContestId = 3,
                    UserId = 1,
                },
                new JuryContest()
                {
                    Id = 4,
                    ContestId = 4,
                    UserId = 1,
                },
                new JuryContest()
                {
                    Id = 5,
                    ContestId = 1,
                    UserId = 2,
                },
                new JuryContest()
                {
                    Id = 6,
                    ContestId = 2,
                    UserId = 3,
                },
            };
        }
        public static ICollection<ParticipantContest> GetParticipantContests()
        {
            return new List<ParticipantContest>()
            {
                 // PhaseOne contest
                new ParticipantContest()
                {
                    ContestId = 1,
                    UserId = 2,
                    PhotoId = 1,
                },
                new ParticipantContest()
                {
                    ContestId = 1,
                    UserId = 3,
                    PhotoId = 2,
                },
                new ParticipantContest()
                {
                    ContestId = 1,
                    UserId = 4,
                    PhotoId = 3,
                },
                new ParticipantContest()
                {
                    ContestId = 1,
                    UserId = 5,
                    PhotoId = 4,
                },
                // PhaseTwo contest
                new ParticipantContest()
                {
                    ContestId = 2,
                    UserId = 2,
                    PhotoId = 5,
                },
                new ParticipantContest()
                {
                    ContestId = 2,
                    UserId = 3,
                    PhotoId = 6,
                },
                new ParticipantContest()
                {
                    ContestId = 2,
                    UserId = 4,
                    PhotoId = 7,
                },
                new ParticipantContest()
                {
                    ContestId = 2,
                    UserId = 5,
                    PhotoId = 8,
                },
                // Finished contest
                new ParticipantContest()
                {
                    ContestId = 3,
                    UserId = 2,
                    PhotoId = 9,
                },
                new ParticipantContest()
                {
                    ContestId = 3,
                    UserId = 3,
                    PhotoId = 10,
                },
                new ParticipantContest()
                {
                    ContestId = 3,
                    UserId = 4,
                    PhotoId = 11,
                },
                new ParticipantContest()
                {
                    ContestId = 3,
                    UserId = 5,
                    PhotoId = 12,
                },
                // Portraits contest
                new ParticipantContest()
                {
                    ContestId = 4,
                    UserId = 6,
                    PhotoId = 13,
                },
            };
        }
        public static ICollection<Phase> GetPhases()
        {
            return new List<Phase>()
            {
                new Phase()
                {
                    Id = 3,
                   Name = Constants.PhasesSeed.Finished
                },
                new Phase()
                {
                    Id = 2,
                   Name = Constants.PhasesSeed.PhaseII
                },
                new Phase()
                {
                    Id = 1,
                   Name = Constants.PhasesSeed.PhaseI
                },
            };
        }
        public static ICollection<PhotoReview> GetPhotoReviews()
        {
            return new List<PhotoReview>()
            {
                new PhotoReview()
                {
                    Id = 1,
                    JuryContestId = 1,
                    PhotoId = 1,
                    Score = 4,
                    Checkbox = false,
                    Comment = "nice",
                },
                new PhotoReview()
                {
                    Id = 2,
                    JuryContestId = 1,
                    PhotoId = 2,
                    Score = 10,
                    Comment = "Extraordinary",
                    Checkbox = false,
                },
                new PhotoReview()
                {
                    Id = 3,
                    JuryContestId = 1,
                    PhotoId = 3,
                    Score = 6,
                    Comment = "nice",
                    Checkbox = false,
                },
                new PhotoReview()
                {
                    Id = 4,
                    JuryContestId = 1,
                    PhotoId = 4,
                    Score = 6,
                    Comment = "nice",
                    Checkbox = false,
                },
                new PhotoReview()
                {
                    Id = 5,
                    JuryContestId = 1,
                    PhotoId = 5,
                    Score = 8,
                    Comment = "nice",
                    Checkbox = false,
                },
                new PhotoReview()
                {
                    Id = 6,
                    JuryContestId = 1,
                    PhotoId = 6,
                    Score = 4,
                    Comment = "nice",
                    Checkbox = false,
                },
                new PhotoReview()
                {
                    Id = 7,
                    JuryContestId = 1,
                    PhotoId = 7,
                    Score = 8,
                    Comment = "nice",
                    Checkbox = false,
                },
                new PhotoReview()
                {
                    Id = 8,
                    JuryContestId = 1,
                    PhotoId = 8,
                    Score = 5,
                    Comment = "nice",
                    Checkbox = false,
                },
                new PhotoReview()
                {
                    Id = 9,
                    JuryContestId = 4,
                    PhotoId = 1,
                    Score = 5,
                    Comment = "nice",
                    Checkbox = false,
                },
                new PhotoReview()
                {
                    Id = 10,
                    JuryContestId = 5,
                    PhotoId = 2,
                    Score = 5,
                    Comment = "nice",
                    Checkbox = false,
                },
            };
        }
        public static ICollection<Photo> GetPhotos()
        {
            return new List<Photo>()
            {
                new Photo()
                {
                    Id = 1,
                    ContestId = 1,
                    Title = "Squirrel",
                    Story = "Looking down",
                    Url = Constants.ImagesSeed.WildlifeImgUrl,
                },
                new Photo()
                {
                    Id = 2,
                    ContestId = 1,
                    Title = "Bath time",
                    Story = "On my way",
                    Url = Constants.ImagesSeed.WildlifeImg2Url,
                },
                new Photo()
                {
                    Id = 3,
                    ContestId = 1,
                    Title = "Fight in the night",
                    Story = "Subway fighters",
                    Url = Constants.ImagesSeed.WildlifeImg3Url,
                },
                new Photo()
                {
                    Id = 4,
                    ContestId = 1,
                    Title = "I can climb it",
                    Story = "Not a long way, we can climb it",
                    Url = Constants.ImagesSeed.WildlifeImg4Url,
                },
                new Photo()
                {
                    Id = 5,
                    ContestId = 2,
                    Title = "Fight in the night",
                    Story = "Subway fighters",
                    Url = Constants.ImagesSeed.WildlifeImg3Url,
                },
                new Photo()
                {
                    Id = 6,
                    ContestId = 2,
                    Title = "I can climb it",
                    Story = "Not a long way, we can climb it",
                    Url = Constants.ImagesSeed.WildlifeImg4Url,
                },
                new Photo()
                {
                    Id = 7,
                    ContestId = 2,
                    Title = "Can I have some?",
                    Story = "Hungry birds",
                    Url = Constants.ImagesSeed.WildlifeImg5Url,
                },
                new Photo()
                {
                    Id = 8,
                    ContestId = 2,
                    Title = "Git It!",
                    Story = "Got it!",
                    Url = Constants.ImagesSeed.WildlifeImg6Url,
                },

                new Photo()
                {
                    Id = 9,
                    ContestId = 3,
                    Title = "Squirrel",
                    Story = "Looking down",
                    Url = Constants.ImagesSeed.WildlifeImgUrl,
                },
                new Photo()
                {
                    Id = 10,
                    ContestId = 3,
                    Title = "Bath time",
                    Story = "On my way",
                    Url = Constants.ImagesSeed.WildlifeImg2Url,
                },
                new Photo()
                {
                    Id = 11,
                    ContestId = 3,
                    Title = "Fight in the night",
                    Story = "Subway fighters",
                    Url = Constants.ImagesSeed.WildlifeImg3Url,
                },
                new Photo()
                {
                    Id = 12,
                    ContestId = 3,
                    Title = "I can climb it",
                    Story = "Not a long way, we can climb it",
                    Url = Constants.ImagesSeed.WildlifeImg4Url,
                },
                new Photo()
                {
                    Id = 13,
                    ContestId = 4,
                    Title = "Smile",
                    Story = "Just a nice picture",
                    Url = Constants.ImagesSeed.PortraitImgUrlCover,
                }
            };
        }
        public static ICollection<Rank> GetRanks()
        {
            return new List<Rank>()
            {
                new Rank()
                {
                    Name = Constants.RanksSeed.Junkie,
                },
                new Rank()
                {
                    Name = Constants.RanksSeed.Enthusiast,
                },
                new Rank()
                {
                    Name = Constants.RanksSeed.Master,
                },
                new Rank()
                {
                    Name = Constants.RanksSeed.WiseAndBenevolentPhotoDictator,
                },
            };
        }

        public async static Task DatabaseILikeYou(FullFraimDbContext context)
        {
            await context.ContestCategories.AddRangeAsync(GetContestCategories());
            await context.ContestPhases.AddRangeAsync(GetContestPhases());
            await context.Contests.AddRangeAsync(GetContests());
            await context.ContestTypes.AddRangeAsync(GetContestTypes());
            await context.Phases.AddRangeAsync(GetPhases());
            await context.PhotoReviews.AddRangeAsync(GetPhotoReviews());
            await context.Photos.AddRangeAsync(GetPhotos());
            await context.Ranks.AddRangeAsync(GetRanks());
        }
    }
}
