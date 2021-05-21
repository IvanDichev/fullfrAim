using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Contests;
using FullFraim.Models.ViewModels;
using FullFraim.Models.ViewModels.Dashboard;
using System.Linq;

namespace Utilities.Mapper
{
    public static class ContestMapper
    {
        public static ContestDto MapToDto(this ContestViewModel model)
        {
            return new ContestDto()
            {
                Name = model.Name,
                Cover_Url = model.Cover_Url,
                Description = model.Description,
                ContestCategoryId = model.ContestCategoryId,
                ContestTypeId = model.ContestTypeId,
            };
        }

        public static ContestViewModel MapToView(this ContestDto model)
        {
            return new ContestViewModel()
            {
                Name = model.Name,
                Cover_Url = model.Cover_Url,
                Description = model.Description,
                ContestCategoryId = model.ContestCategoryId,
                ContestTypeId = model.ContestTypeId,
            };
        }

        public static DashboardViewModel MapToViewDashboard(this ContestDto model) 
        {
            return new DashboardViewModel()
            {
                Name = model.Name,
                Cover_Url = model.Cover_Url,
                Description = model.Description,
            };
        }

        public static Contest MapToRaw(this ContestDto model)
        {
            return new Contest()
            {
                Id = model.Id,
                Name = model.Name,
                Cover_Url = model.Cover_Url,
                Description = model.Description,
                ContestCategoryId = model.ContestCategoryId,
                ContestTypeId = model.ContestTypeId,
            };
        }

        public static IQueryable<ContestDto> MapToDto(this IQueryable<Contest> query)
        {
            return query.Select(x =>
            new ContestDto()
            {
                Id = x.Id,
                Name = x.Name,
                Cover_Url = x.Cover_Url,
                Description = x.Description,
                ContestCategoryId = x.ContestCategoryId,
                ContestTypeId = x.ContestTypeId,
            });
        }
    }
}
