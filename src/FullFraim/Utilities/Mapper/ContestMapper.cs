using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Contests;
using FullFraim.Models.ViewModels;

namespace Utilities.Mapper
{
    public static class ContestMapper
    {

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

        public static ContestModel MapToDto(this Contest model)
        {
            return new ContestModel()
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
    }
}
