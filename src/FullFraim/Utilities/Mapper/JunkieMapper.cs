using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.PhotoJunkies;
using FullFraim.Models.Dto_s.Users;
using FullFraim.Models.ViewModels.Dashboard;
using System.Collections.Generic;
using System.Linq;

namespace Utilities.Mapper
{
    public static class JunkieMapper
    {
        public static IQueryable<PhotoJunkieDto> MapToJunkieDto(this IQueryable<User> query)
        {
            return query.Select(x =>
            new PhotoJunkieDto()
            {
               FirstName = x.FirstName,
               LastName = x.LastName,
               Points = (int)x.Points,
               Rank = x.Rank.Name
            });
        } 

        public static PointsTillNextViewModel MapToPointsViewModel
            (this PhotoJunkieRankDto model, string fullName)
        {
            return new PointsTillNextViewModel()
            {
                FullUserName = fullName,
                Points = model.PointsTillNextRank
                .ToString(),
            };
        }
        
        public static PhotoJunkieDto MapToJunkiDto(this User model)
        {
            return new PhotoJunkieDto()
            {
               FirstName = model.FirstName,
               LastName = model.LastName,
               Points = (int)model.Points,
            };
        }
        
        public static IEnumerable<PhotoJunkieDto> MapToJunkieDto(this IEnumerable<User> model)
        {
            return model.Select(x => new PhotoJunkieDto()
            {
               FirstName = x.FirstName,
               LastName = x.LastName,
               Points = (int)x.Points,
            });
        }
    }
}
