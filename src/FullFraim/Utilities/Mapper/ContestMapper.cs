using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Contests;
using FullFraim.Models.ViewModels;
using System.Linq;

namespace Utilities.Mapper
{
    public static class ContestMapper
    {
        public static ContestModel MapToDto(this ContestViewModel model)
        {
            return new ContestModel()
            {
                Name = model.Name,
                Cover_Url = model.Cover_Url,
                Description = model.Description,
                ContestCategoryId = model.ContestCategoryId,
                ContestTypeId = model.ContestTypeId,
                PhaseId = model.PhaseId
            };
        }

        public static ContestViewModel MapToView(this ContestModel model)
        {
            return new ContestViewModel()
            {
                Name = model.Name,
                Cover_Url = model.Cover_Url,
                Description = model.Description,
                ContestCategoryId = model.ContestCategoryId,
                ContestTypeId = model.ContestTypeId,
                PhaseId = model.PhaseId
            };
        }

        public static Contest MapToRaw(this ContestModel model)
        {
            return new Contest()
            {
                Id = model.Id,
                Name = model.Name,
                Cover_Url = model.Cover_Url,
                Description = model.Description,
                ContestCategoryId = model.ContestCategoryId,
                ContestTypeId = model.ContestTypeId,
                PhaseId = model.PhaseId
            };
        }

        public static IQueryable<ContestModel> MapToDto(this IQueryable<Contest> query)
        {
            return query.Select(x =>
            new ContestModel()
            {
                Id = x.Id,
                Name = x.Name,
                Cover_Url = x.Cover_Url,
                Description = x.Description,
                ContestCategoryId = x.ContestCategoryId,
                ContestTypeId = x.ContestTypeId,
                PhaseId = x.PhaseId
            });
        }
    }
}
