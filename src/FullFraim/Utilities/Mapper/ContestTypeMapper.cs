using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.ContestTypes;

namespace Utilities.Mapper
{
    public static class ContestTypeMapper
    {
        public static ContestTypeModel MapToDto(this ContestType model)
        {
            return new ContestTypeModel()
            {
                Id = model.Id,
                Name = model.Name,
            };
        }

        public static ContestType MapToRaw(this ContestTypeModel model)
        {
            return new ContestType()
            {
                Id = model.Id,
                Name = model.Name,
            };
        }
    }
}
