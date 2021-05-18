using FullFraim.Models.Dto_s.Contests;
using FullFraim.Models.ViewModels;

namespace Utilities.Mapper
{
    public static class ContestMapper
    {
        public static ContestViewModel MapToView(this InputContestModel model)
        {
            return new ContestViewModel()
            {
                Name = model.Name,
                Cover_Url = model.Cover_Url,
                Description = model.Description,
                ContestCategory = model.ContestCategory,
                ContestType = model.ContestType,
                Phase = model.Phase
            };
        }

        public static InputContestModel MapToDto (this ContestViewModel model)
        {
            return new InputContestModel()
            {
                Name = model.Name,
                Cover_Url = model.Cover_Url,
                Description = model.Description,
                ContestCategory = model.ContestCategory,
                ContestType = model.ContestType,
                Phase = model.Phase
            };
        }
    }
}
