using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Reviews;
using FullFraim.Models.ViewModels.Contest;

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
              //  PhotoUrl = model.Photo.Url,
                Score = model.Score,
            };
        }
        public static InputGiveReviewDto MapToInputGiveReviewDto(this GiveReviewViewModel model)
        {
            return new InputGiveReviewDto()
            {
                //Checkbox = model.Checkbox,
               // Comment = model.Comment,
                JuryId = model.JuryId,
                PhotoId = model.PhotoId,
               // PhotoUrl = model.PhotoUrl,
               // Score = model.Score
            };
        }
    }
}
