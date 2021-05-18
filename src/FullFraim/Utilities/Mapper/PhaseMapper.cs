using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Phases;

namespace Utilities.Mapper
{
    public static class PhaseMapper
    {
        public static OutputPhaseModel MapToDto(this Phase model)
        {
            return new OutputPhaseModel()
            {
                Name = model.Name,
            };
        }

        public static Phase MapToRaw(this InputPhaseModel model)
        {
            return new Phase()
            {
                Name = model.Name,
            };
        }
    }
}
