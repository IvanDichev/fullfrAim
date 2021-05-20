using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Phases;
using System.Linq;

namespace Utilities.Mapper
{
    public static class PhaseMapper
    {
        public static IQueryable<PhaseModel> MapToDto(this IQueryable<Phase> query)
        {
            return query.Select(x =>
            new PhaseModel()
            {
                Id = x.Id,
                Name = x.Name
            });
        }

        public static Phase MapToRaw(this PhaseModel model)
        {
            return new Phase()
            {
                Id = model.Id,
                Name = model.Name,
            };
        }
    }
}
