using FullFraim.Models.Dto_s.User;
using FullFraim.Models.ViewModels.Contest;
using System;
using System.Collections.Generic;

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

        public ICollection<int> Jury { get; set; }
        public ICollection<int> Participants { get; set; }
    }
}
