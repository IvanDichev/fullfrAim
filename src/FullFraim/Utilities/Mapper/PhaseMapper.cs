using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Phases;

namespace Utilities.Mapper
{
    public static class PhaseMapper
    {
        public static PhaseModel MapToDto(this Phase model)
        {
            return new PhaseModel()
            {
                Id = model.Id,
                Name = model.Name,
            };
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
