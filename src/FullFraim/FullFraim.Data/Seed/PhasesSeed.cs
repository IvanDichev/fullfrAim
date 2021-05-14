using FullFraim.Data.Models;
using System.Collections.Generic;

namespace FullFraim.Data.Seed
{
    public static class PhasesSeed
    {
        public static readonly List<Phase> SeedData = new List<Phase>()
        { 
          new Phase()
          { 
             Name = "Phase I"
          },
          new Phase()
          {
             Name = "Phase II"
          },
          new Phase()
          {
             Name = "Finished"
          }
        };
    }
}
