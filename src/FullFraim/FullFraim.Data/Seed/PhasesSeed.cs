using FullFraim.Data.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullFraim.Data.Seed
{
    public class PhasesSeed : ISeeder
    {
        public static readonly List<Phase> SeedData = new List<Phase>()
        {
            new Phase()
            {
               Id = 1,
               Name = Constants.PhasesSeed.PhaseI
            },
            new Phase()
            {
               Id = 2,
               Name = Constants.PhasesSeed.PhaseII
            },
            new Phase()
            {
               Id = 3,
               Name = Constants.PhasesSeed.Finished
            }
        };

        public async Task SeedAsync(FullFraimDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Phases.Any())
                await dbContext.AddAsync(SeedData);
        }
    }
}
