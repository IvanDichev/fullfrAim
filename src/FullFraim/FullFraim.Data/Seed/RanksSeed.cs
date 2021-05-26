using FullFraim.Data.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullFraim.Data.Seed
{
    public class RanksSeed : ISeeder
    {
        public static readonly List<Rank> SeedData = new List<Rank>()
        {
            new Rank()
            {
                Id = 1,
                Name = Constants.RanksSeed.Junkie,
            },
            new Rank()
            {
                Id = 2,
                Name = Constants.RanksSeed.Enthusiast,
            },
            new Rank()
            {
                Id = 3,
                Name = Constants.RanksSeed.Master,
            },
            new Rank()
            {
                Id = 4,
                Name = Constants.RanksSeed.WiseAndBenevolentPhotoDictator,
            },
        };

        public async Task SeedAsync(FullFraimDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Ranks.Any())
                await dbContext.AddAsync(SeedData);
        }
    }
}
