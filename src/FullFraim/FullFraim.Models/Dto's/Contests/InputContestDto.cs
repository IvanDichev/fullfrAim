using FullFraim.Models.ViewModels.Contest;
using System;

namespace FullFraim.Models.Dto_s.Contests
{
    public class InputContestDto
    {
        public string Name { get; set; }

        public string Cover_Url { get; set; }

        public string Description { get; set; }

        public PhasesHelperModel Phases { get; set; }

        public int ContestCategoryId { get; set; }
               
        public int ContestTypeId { get; set; }
    }
}
