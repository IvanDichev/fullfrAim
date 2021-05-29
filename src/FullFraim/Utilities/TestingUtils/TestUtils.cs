using FullFraim.Data.Models;
using Microsoft.EntityFrameworkCore;
using Shared;
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
