﻿using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.ContestTypes;

namespace Utilities.Mapper
{
    public static class ContestTypeMapper
    {
        public static ContestTypeModel MapToDto(this ContestType model)
        {
            return new ContestTypeModel()
            {
                Name = model.Name,
            };
        }

        public static ContestType MapToRaw(this ContestTypeModel model)
        {
            return new ContestType()
            {
                Name = model.Name,
            };
        }
    }
}
