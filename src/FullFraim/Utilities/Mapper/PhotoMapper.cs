using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Photos;
using System.Linq;

namespace Utilities.Mapper
{
    public static class PhotoMapper
    {
        public static IQueryable<PhotoModel> MapToDto(this IQueryable<Photo> query)
        {
            return query.Select(x =>
                   new PhotoModel()
                   {
                       Id = x.Id,
                       Name = x.Name,
                       Description = x.Description,
                       Url = x.Url,
                      // ParticipantId = x.Participant.Id
                   }
               );
        }
        public static Photo MapToRaw(this PhotoModel model)
        {
            return new Photo()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Url = model.Url,
                // Participant = model.ParticipantId.
            };
        }
    }
}
