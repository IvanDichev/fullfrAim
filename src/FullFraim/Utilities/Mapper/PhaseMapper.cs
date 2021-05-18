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
                Name = model.Name,
            };
        }

        public static Phase MapToRaw(this PhaseModel model)
        {
            return new Phase()
            {
                Name = model.Name,
            };
        }
    }
}
