using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.ContestCategories;

namespace Utilities.Mapper
{
    public static class ContestCategoryMapper
    {
        public static OutputContestCategoryModel MapToDto (this ContestCategory model)
        {
            return new OutputContestCategoryModel()
            {
                Name = model.Name,
            };
        }

        public static ContestCategory MapToRaw(this InputContestCategoryModel model)
        {
            return new ContestCategory()
            {
                Name = model.Name,
            };
        }
    }
}

