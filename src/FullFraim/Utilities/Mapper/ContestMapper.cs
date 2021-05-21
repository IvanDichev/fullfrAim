using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Contests;
using FullFraim.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Utilities.Mapper
{
    public static class ContestMapper
    {
        public static InputContestDto MapToDto(this ContestViewModel model)
        {
            return new InputContestDto()
            {
                Name = model.Name,
                Cover_Url = model.Cover_Url,
                Description = model.Description,
                ContestCategoryId = model.ContestCategoryId,
                ContestTypeId = model.ContestTypeId,
            };
        }

        public static OutputContestDto MapToDto(this InputContestDto model)
        {
            return new OutputContestDto()
            {
                Name = model.Name,
                Cover_Url = model.Cover_Url,
                Description = model.Description,
                ContestCategoryId = model.ContestCategoryId,
                ContestTypeId = model.ContestTypeId,
            };
        }

        public static ContestViewModel MapToView(this InputContestDto model)
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

        public static Contest MapToRaw(this InputContestDto model)
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

        public static IQueryable<OutputContestDto> MapToDto(this IQueryable<Contest> query)
        {
            return query.Select(x =>
            new OutputContestDto()
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
