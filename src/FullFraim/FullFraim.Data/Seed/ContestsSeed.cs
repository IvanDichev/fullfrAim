using FullFraim.Data.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullFraim.Data.Seed
{
    public class ContestsSeed : ISeeder
    {
        public static readonly List<Contest> SeedData = new List<Contest>()
        {
            new Contest()
            {
                Name = "WildlifePhaseOne",
                Description = "PhaseOne",
                Cover_Url = Constants.ImagesSeed.WildlifeImgUrlCover,
                ContestCategoryId = 12,
                ContestTypeId = 1,
                CreatedOn = DateTime.UtcNow,
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
                Name = "WildlifePhaseThree",
                Description = "PhaseThree",
                Cover_Url = Constants.ImagesSeed.WildlifeImgUrlCover,
                ContestCategoryId = 12,
                ContestTypeId = 1,
                CreatedOn = DateTime.UtcNow.AddDays(-2),
            },
            new Contest()
            {
                Name = "Portrait",
                Description = "Portrait contest - PhaseOne",
                Cover_Url = Constants.ImagesSeed.PortraitImgUrlCover,
                ContestCategoryId = 10,
                ContestTypeId = 2,
                CreatedOn = DateTime.UtcNow,
            }
        };

        public async Task SeedAsync(FullFraimDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Contests.Any())
                await dbContext.AddRangeAsync(SeedData);
        }
    }
}
