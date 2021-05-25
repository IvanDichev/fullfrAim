using FullFraim.Data.Models;
using Shared;
using System;
using System.Collections.Generic;

namespace FullFraim.Data.Seed
{
    public static class ContestsSeed
    {
        public static readonly List<Contest> SeedData = new List<Contest>()
        {
            new Contest()
            {
                Id = 1,
                Name = "WildlifePhaseOne",
                Cover_Url = Constants.ImagesSeed.WildlifeImgUrlCover,
                ContestCategoryId = 12,
                ContestTypeId = 1,
                CreatedOn = DateTime.UtcNow,
            },
            new Contest()
            {
                Id = 2,
                Name = "WildlifePhaseTwo",
                Cover_Url = Constants.ImagesSeed.WildlifeImgUrlCover,
                ContestCategoryId = 12,
                ContestTypeId = 1,
                CreatedOn = DateTime.UtcNow.AddDays(-30),
            },
            new Contest()
            {
                Id = 3,
                Name = "WildlifePhaseThree",
                Cover_Url = Constants.ImagesSeed.WildlifeImgUrlCover,
                ContestCategoryId = 12,
                ContestTypeId = 1,
                CreatedOn = DateTime.UtcNow.AddDays(-2),
            },
            new Contest()
            {
                Id = 4,
                Name = "Portrait",
                Cover_Url = Constants.ImagesSeed.PortraitImgUrlCover,
                ContestCategoryId = 10,
                ContestTypeId = 2,
                CreatedOn = DateTime.UtcNow,
            }
        };
    }
}
