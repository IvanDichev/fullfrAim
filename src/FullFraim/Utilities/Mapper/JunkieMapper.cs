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
        public static IQueryable<PhotoJunkyDto> MapToJunkieDto(this IQueryable<User> query)
        {
            return query.Select(x =>
            new PhotoJunkyDto()
            {
               Id = x.Id,
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
        
        public static PhotoJunkyDto MapToJunkiDto(this User model)
        {
            return new PhotoJunkyDto()
            {
               FirstName = model.FirstName,
               LastName = model.LastName,
               Points = (int)model.Points,
            };
        }
        
        public static IEnumerable<PhotoJunkyDto> MapToJunkieDto(this IEnumerable<User> model)
        {
            return model.Select(x => new PhotoJunkyDto()
            {
               FirstName = x.FirstName,
               LastName = x.LastName,
               Points = (int)x.Points,
            });
        }
    }
}
