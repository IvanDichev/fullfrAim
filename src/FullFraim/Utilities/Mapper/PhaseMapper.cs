using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Phases;
using System.Linq;

namespace Utilities.Mapper
{
    public static class PhaseMapper
    {
        public static IQueryable<PhaseDto> MapToDto(this IQueryable<Phase> query)
        {
            return query.Select(x =>
            new PhaseDto()
            {
                Id = x.Id,
                Name = x.Name
            });
        }

        public static Phase MapToRaw(this PhaseDto model)
        {
            return new Phase()
            {
                Id = model.Id,
                Name = model.Name,
            };
        }
    }
}
