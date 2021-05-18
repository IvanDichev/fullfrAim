using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.ContestTypes;

namespace Utilities.Mapper
{
    public static class ContestTypeMapper
    {
        public static OutputContestTypeModel MapToDto(this ContestType model)
        {
            return new OutputContestTypeModel()
            {
                Name = model.Name,
            };
        }

        public static ContestType MapToRaw(this InputContestTypeModel model)
        {
            return new ContestType()
            {
                Name = model.Name,
            };
        }
    }
}
