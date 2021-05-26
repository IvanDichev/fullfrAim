﻿using FullFraim.Data.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullFraim.Data.Seed
{
    public class ContestTypesSeed : ISeeder
    {
        public static readonly List<ContestType> SeedData = new List<ContestType>()
        {
            new ContestType()
            {
               Name = Constants.ContestTypeSeed.Open
            },
            new ContestType()
            {
               Name = Constants.ContestTypeSeed.Invitational
            }
        };

        public async Task SeedAsync(FullFraimDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.ContestTypes.Any())
                await dbContext.AddRangeAsync(SeedData);
        }
    }
}
