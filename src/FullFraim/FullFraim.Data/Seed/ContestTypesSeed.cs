using FullFraim.Data.Models;
using Shared;
using System.Collections.Generic;

namespace FullFraim.Data.Seed
{
    public static class ContestTypesSeed
    {
        public static readonly List<ContestType> SeedData = new List<ContestType>()
        {
            new ContestType()
            {
               Id = 1,
               Name = Constants.ContestTypeSeed.Open
            },
            new ContestType()
            {
               Id = 2,
               Name = Constants.ContestTypeSeed.Invitational
            }
        };
    }
}
