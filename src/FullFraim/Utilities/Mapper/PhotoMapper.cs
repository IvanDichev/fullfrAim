using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Photos;
using FullFraim.Models.Dto_s.Reviews;
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

        public static IQueryable<ContestSubmissionOutputDto> MapToContestSubmissionOutputDto(this IQueryable<Photo> query)
        {
            return query.Select(p => new ContestSubmissionOutputDto()
            {
                PhotoId = p.Id,
                AuthorName = $"{p.Participant.User.FirstName} {p.Participant.User.LastName}",
                PhotoTitle = p.Title,
                PhotoUrl = p.Url,
                Description = p.Story,
                Reviews = p.PhotoReviews.Select(pr => new ReviewDto()
                {
                    AuthorName = $"{pr.JuryContest.User.FirstName} {pr.JuryContest.User.LastName}",
                    Comment = pr.Comment,
                    ReviewId = pr.Id,
                    Score = (int)pr.Score,
                }).ToList(),
            });

        }
    }
}

