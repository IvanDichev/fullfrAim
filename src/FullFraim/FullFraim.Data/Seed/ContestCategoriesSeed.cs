using FullFraim.Data.Models;
using System.Collections.Generic;

namespace FullFraim.Data.Seed
{
    public static class ContestCategoriesSeed
    {
        public static readonly List<ContestCategory> SeedData = new List<ContestCategory>()
        {
           new ContestCategory()
           {
              Name = "Abstract"
           },
           new ContestCategory()
           {
              Name = "Architecture"
           },
           new ContestCategory()
           {
              Name = "Conceptual"
           },
           new ContestCategory()
           {
              Name = "Fashion/Beauty"
           },
           new ContestCategory()
           { 
              Name = "Fine Art"
           },
           new ContestCategory()
           {
              Name = "Landscapes"
           },
           new ContestCategory()
           {
              Name = "Nature"
           },
           new ContestCategory()
           {
              Name = "Nude"
           },
           new ContestCategory()
           {
              Name = "Photojournalism"
           },
           new ContestCategory()
           {
              Name = "Portrait"
           },
           new ContestCategory()
           {
              Name = "Street"
           },
           new ContestCategory()
           {
              Name = "Wildlife"
           }
        };
    }
}
