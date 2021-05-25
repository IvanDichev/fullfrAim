using FullFraim.Data.Models;
using System.Collections.Generic;

namespace FullFraim.Data.Seed
{
    public class JuryContestsSeed
    {
        public static readonly List<JuryContest> SeedData = new List<JuryContest>()
        {
            new JuryContest()
            {
                Id = 1,
                ContestId = 1,
                UserId = 1,
            },
            new JuryContest()
            {
                Id = 2,
                ContestId = 2,
                UserId = 1,
            },
            new JuryContest()
            {
                Id = 3,
                ContestId = 3,
                UserId = 1,
            },
            new JuryContest()
            {
                Id = 4,
                ContestId = 4,
                UserId = 1,
            },

        };
    }
}
