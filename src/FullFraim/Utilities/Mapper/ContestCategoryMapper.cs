using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.ContestCategories;

namespace Utilities.Mapper
{
    public static class ContestCategoryMapper
    {
        public static ContestCategoryModel MapToDto (this ContestCategory model)
        {
            return new ContestCategoryModel()
            {
                Id = model.Id,
                Name = model.Name,
            };
        }

        public static ContestCategory MapToRaw(this ContestCategoryModel model)
        {
            return new ContestCategory()
            {
                Id = model.Id,
                Name = model.Name,
            };
        }
    }
}

