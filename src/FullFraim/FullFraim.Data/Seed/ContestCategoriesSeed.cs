using FullFraim.Data.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullFraim.Data.Seed
{
    public class ContestCategoriesSeed : ISeeder
    {
        public static readonly List<ContestCategory> SeedData = new List<ContestCategory>()
        {
           new ContestCategory()
           {
              Id = 1,
              Name = Constants.ConstestCategorySeed.Abstract
           },
           new ContestCategory()
           {
               Id = 2,
              Name = Constants.ConstestCategorySeed.Architecture
           },
           new ContestCategory()
           {
               Id = 3,
              Name = Constants.ConstestCategorySeed.Conceptual
           },
           new ContestCategory()
           {
               Id = 4,
              Name = Constants.ConstestCategorySeed.Fashion_Beauty
           },
           new ContestCategory()
           {
               Id = 5,
              Name = Constants.ConstestCategorySeed.Fine_Art
           },
           new ContestCategory()
           {
               Id = 6,
              Name = Constants.ConstestCategorySeed.Landscapes
           },
           new ContestCategory()
           {
               Id = 7,
              Name = Constants.ConstestCategorySeed.Nature
           },
           new ContestCategory()
           {
               Id = 8,
              Name = Constants.ConstestCategorySeed.Boudoir
           },
           new ContestCategory()
           {
               Id = 9,
              Name = Constants.ConstestCategorySeed.Photojournalism
           },
           new ContestCategory()
           {
               Id = 10,
              Name = Constants.ConstestCategorySeed.Portrait
           },
           new ContestCategory()
           {
               Id = 11,
              Name = Constants.ConstestCategorySeed.Street
           },
           new ContestCategory()
           {
               Id = 12,
              Name = Constants.ConstestCategorySeed.Wildlife
           }
        };

        public async Task SeedAsync(FullFraimDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.ContestCategories.Any())
                await dbContext.AddAsync(SeedData);
        }
    }
}
