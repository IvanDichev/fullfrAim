using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Juries;

namespace Utilities.Mapper
{
    public static class PhotoReviewMapper
    {
        public static OutputGiveReviewDto MapToOutputGiveReviewDto(this PhotoReview model)
        {
            return new OutputGiveReviewDto()
            {
                Checkbox = model.Checkbox,
                Comment =model.Comment,
                JuryId = model.JuryContestId,
                PhotoId = model.PhotoId,
                Score = model.Score,
            };
        }
    }
}
