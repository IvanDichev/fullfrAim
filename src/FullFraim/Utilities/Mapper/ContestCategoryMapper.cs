using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.ContestCategories;
using System.Linq;

namespace Utilities.Mapper
{
    public static class ContestCategoryMapper
    {
        public static IQueryable<ContestCategoryModel> MapToDto(this IQueryable<ContestCategory> query)
        {
            return query.Select(x =>
                new ContestCategoryModel()
                {
                    Id = x.Id,
                    Name = x.Name
                }
            );
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

