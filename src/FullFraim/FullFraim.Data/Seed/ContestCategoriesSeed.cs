using FullFraim.Data.Models;
using Shared;
using System.Collections.Generic;

namespace FullFraim.Data.Seed
{
    public static class ContestCategoriesSeed
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
              Name = Constants.ConstestCategorySeed.Nude
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
    }
}
