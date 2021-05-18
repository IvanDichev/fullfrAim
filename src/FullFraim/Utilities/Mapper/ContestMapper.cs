using FullFraim.Models.Dto_s.Contests;
using FullFraim.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Mapper
{
    public static class ContestMapper
    {
        public static InputContestViewModel MapToInputView(this InputContestModel model)
        {
            return new InputContestViewModel()
            {
                Name = model.Name,
                Cover_Url = model.Cover_Url,
                Description = model.Description,
                p
            }
        }
    }
}
