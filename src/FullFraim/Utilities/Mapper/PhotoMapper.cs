using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Photos;
using System.Linq;

namespace Utilities.Mapper
{
    public static class PhotoMapper
    {
        public static IQueryable<PhotoDto> MapToDto(this IQueryable<Photo> query)
        {
            return query.Select(p => new PhotoDto()
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Story,
                SubmitterName = p.Participant.User.FirstName + p.Participant.User.LastName,
                Url = p.Url,
            });
        }
    }
}
