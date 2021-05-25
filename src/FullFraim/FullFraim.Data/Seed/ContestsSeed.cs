using FullFraim.Data.Models;
using Shared;
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
                Name = "Wildlife",
                Cover_Url = Constants.ImagesSeed.WildlifeImgUrlCover,
                ContestCategoryId = 12,
                ContestTypeId = 1,
            },
            new Contest()
            {
                Id = 1,
                Name = "Portrait",
                Cover_Url = Constants.ImagesSeed.PortraitImgUrlCover,
                ContestCategoryId = 10,
                ContestTypeId = 2,
            }
        };
    }
}
