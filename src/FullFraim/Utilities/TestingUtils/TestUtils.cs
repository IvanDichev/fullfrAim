using FullFraim.Data.Models;
using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;

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
                    Name = "Portrait",
                    Description = "Portrait contest - PhaseOne",
                    Cover_Url = Constants.ImagesSeed.PortraitImgUrlCover,
                    ContestCategoryId = 10,
                    ContestTypeId = 2,
                    CreatedOn = DateTime.UtcNow,
                },
                new Contest()
                {
                    Name = "WildlifePhaseThree",
                    Description = "PhaseThree",
                    Cover_Url = Constants.ImagesSeed.WildlifeImgUrlCover,
                    ContestCategoryId = 12,
                    ContestTypeId = 1,
                    CreatedOn = DateTime.UtcNow.AddDays(-2),
                },
                new Contest()
                {
                    Name = "WildlifePhaseTwo",
                    Description = "PhaseTwo",
                    Cover_Url = Constants.ImagesSeed.WildlifeImgUrlCover,
                    ContestCategoryId = 12,
                    ContestTypeId = 1,
                    CreatedOn = DateTime.UtcNow.AddDays(-30),
                },
                new Contest()
                {
                    Name = "WildlifePhaseOne",
                    Description = "PhaseOne",
                    Cover_Url = Constants.ImagesSeed.WildlifeImgUrlCover,
                    ContestCategoryId = 12,
                    ContestTypeId = 1,
                    CreatedOn = DateTime.UtcNow,
                },
            };
        }
        public static ICollection<Photo> GetPhotos()
        {
            return new List<Photo>()
            {
                new Photo()
                {
                    ContestId = 1,
                    Title = "Squirrel",
                    Story = "Looking down",
                    Url = Constants.ImagesSeed.WildlifeImgUrl,
                },
                new Photo()
                {
                    ContestId = 1,
                    Title = "Bath time",
                    Story = "On my way",
                    Url = Constants.ImagesSeed.WildlifeImg2Url,
                },
                new Photo()
                {
                    ContestId = 1,
                    Title = "Fight in the night",
                    Story = "Subway fighters",
                    Url = Constants.ImagesSeed.WildlifeImg3Url,
                },
                new Photo()
                {
                    ContestId = 1,
                    Title = "I can climb it",
                    Story = "Not a long way, we can climb it",
                    Url = Constants.ImagesSeed.WildlifeImg4Url,
                },
                new Photo()
                {
                    ContestId = 2,
                    Title = "Fight in the night",
                    Story = "Subway fighters",
                    Url = Constants.ImagesSeed.WildlifeImg3Url,
                },
                new Photo()
                {
                    ContestId = 2,
                    Title = "I can climb it",
                    Story = "Not a long way, we can climb it",
                    Url = Constants.ImagesSeed.WildlifeImg4Url,
                },
                new Photo()
                {
                    ContestId = 2,
                    Title = "Can I have some?",
                    Story = "Hungry birds",
                    Url = Constants.ImagesSeed.WildlifeImg5Url,
                },
                new Photo()
                {
                    ContestId = 2,
                    Title = "Git It!",
                    Story = "Got it!",
                    Url = Constants.ImagesSeed.WildlifeImg6Url,
                },

                new Photo()
                {
                    ContestId = 3,
                    Title = "Squirrel",
                    Story = "Looking down",
                    Url = Constants.ImagesSeed.WildlifeImgUrl,
                },
                new Photo()
                {
                    ContestId = 3,
                    Title = "Bath time",
                    Story = "On my way",
                    Url = Constants.ImagesSeed.WildlifeImg2Url,
                },
                new Photo()
                {
                    ContestId = 3,
                    Title = "Fight in the night",
                    Story = "Subway fighters",
                    Url = Constants.ImagesSeed.WildlifeImg3Url,
                },
                new Photo()
                {
                    ContestId = 3,
                    Title = "I can climb it",
                    Story = "Not a long way, we can climb it",
                    Url = Constants.ImagesSeed.WildlifeImg4Url,
                },
                new Photo()
                {
                    ContestId = 4,
                    Title = "Smile",
                    Story = "Just a nice picture",
                    Url = Constants.ImagesSeed.PortraitImgUrlCover,
                }
            };
        }


    }
}
