using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Contests;
using FullFraim.Models.ViewModels;

namespace Utilities.Mapper
{
    public static class ContestMapper
    {
        public static ContestViewModel MapToView(this ContestModel model)
        {
            return new ContestViewModel()
            {
                Name = model.Name,
                ContestCategoryId = model.ContestCategoryId,
                Cover_Url = model.Cover_Url,
                ContestTypeId = model.ContestTypeId,
                Description = model.Description,
                PhaseId = model.PhaseId
            };
        }

        public static ContestModel MapToDto(this ContestViewModel model)
        {
            return new ContestModel()
            {
                Name = model.Name,
                ContestCategoryId = model.ContestCategoryId,
                ContestTypeId = model.ContestTypeId,
                Cover_Url = model.Cover_Url,
                Description = model.Description,
                PhaseId = model.PhaseId
            };
        }

        public static Contest MapToRaw(this ContestModel model)
        {
            return new Contest()
            {
                Name = model.Name,
                Cover_Url = model.Cover_Url,
                Description = model.Description,
                ContestCategoryId = model.ContestCategoryId,
                ContestTypeId = model.ContestTypeId,
                PhaseId = model.PhaseId
            };
        }

        public static ContestModel MapToDto(this Contest model)
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
    }
}
