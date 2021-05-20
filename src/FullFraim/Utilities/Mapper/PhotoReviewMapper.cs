using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.PhotoReview;
using System.Linq;

namespace Utilities.Mapper
{
    public static class PhotoReviewMapper
    {
        public static IQueryable<PhotoReviewModel> MapToDto(this IQueryable<PhotoReview> query)
        {
            return query.Select(x =>
                   new PhotoReviewModel()
                   {
                      Id = x.Id,
                      Comment = x.Comment,
                      Score = x.Score,
                      Checkbox = x.Checkbox,
                      JuryContestId = x.JuryContestId,
                      PhotoId = x.PhotoId
                   }
               );
        }
        public static Photo MapToRaw(this PhotoReviewModel model)
        {
            return new Photo()
            {
               
            };
        }
    }
}
