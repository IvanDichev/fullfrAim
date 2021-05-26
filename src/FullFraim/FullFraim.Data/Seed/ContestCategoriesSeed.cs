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
              Name = Constants.ConstestCategorySeed.Abstract
           },
           new ContestCategory()
           {
              Name = Constants.ConstestCategorySeed.Architecture
           },
           new ContestCategory()
           {
               Name = Constants.ConstestCategorySeed.Conceptual
           },
           new ContestCategory()
           {
               Name = Constants.ConstestCategorySeed.Fashion_Beauty
           },
           new ContestCategory()
           {
               Name = Constants.ConstestCategorySeed.Fine_Art
           },
           new ContestCategory()
           {
               Name = Constants.ConstestCategorySeed.Landscapes
           },
           new ContestCategory()
           {
               Name = Constants.ConstestCategorySeed.Nature
           },
           new ContestCategory()
           {
               Name = Constants.ConstestCategorySeed.Boudoir
           },
           new ContestCategory()
           {
               Name = Constants.ConstestCategorySeed.Photojournalism
           },
           new ContestCategory()
           {
               Name = Constants.ConstestCategorySeed.Portrait
           },
           new ContestCategory()
           {
               Name = Constants.ConstestCategorySeed.Street
           },
           new ContestCategory()
           {
               Name = Constants.ConstestCategorySeed.Wildlife
           }
        };

        public async Task SeedAsync(FullFraimDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.ContestCategories.Any())
                await dbContext.AddRangeAsync(SeedData);
        }
    }
}
