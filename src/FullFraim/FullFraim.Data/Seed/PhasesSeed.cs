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
               Name = Constants.PhasesSeed.Finished
            },
            new Phase()
            {
               Name = Constants.PhasesSeed.PhaseII
            },
            new Phase()
            {
               Name = Constants.PhasesSeed.PhaseI
            },            
        };

        public async Task SeedAsync(FullFraimDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Phases.Any())
                await dbContext.AddRangeAsync(SeedData);
        }
    }
}
