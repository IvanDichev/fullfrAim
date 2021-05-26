using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Users;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace Utilities.Mapper
{
    public static class JunkieMapper
    {
        public static IQueryable<PhotoJunkieDto> MapToDto(this IQueryable<User> query)
        {
            return query.Select(x =>
            new PhotoJunkieDto()
            {
               FirstName = x.FirstName,
               LastName = x.LastName,
               Points = (int)x.Points,
            });
        } 
        
        public static PhotoJunkieDto MapToDto(this User model)
        {
            return new PhotoJunkieDto()
            {
               FirstName = model.FirstName,
               LastName = model.LastName,
               Points = (int)model.Points,
            };
        }
        
        public static IEnumerable<PhotoJunkieDto> MapToDto(this IEnumerable<User> model)
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
