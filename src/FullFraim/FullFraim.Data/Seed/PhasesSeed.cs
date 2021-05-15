using FullFraim.Data.Models;
using Shared;
using System.Collections.Generic;

namespace FullFraim.Data.Seed
{
    public static class PhasesSeed
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
    }
}
