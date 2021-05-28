using FullFraim.Models.Dto_s.PhotoJunkies;

namespace Utilities.Mapper
{
    public static class EnrollMapper
    {
        public static InputEnrollForContestDto MapToDto(this InpurEnrollForContestModel model)
        {
            return new InputEnrollForContestDto()
            {
                ContestId = model.ContestId,
                ImageDescription = model.ImageDescription,
                ImageTitle = model.ImageTitle,
                UserId = model.UserId,
            };
        }
    }
}
