using System;

namespace FullFraim.Models.Dto_s.Contests
{
    public class InputContestDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Cover_Url { get; set; }

        public string Description { get; set; }

        public DateTime PhaseI_EndTime { get; set; }

        public DateTime PhaseII_EndTime { get; set; }

        public DateTime PhaseIII_EndTime { get; set; }

        public int ContestCategoryId { get; set; }
               
        public int ContestTypeId { get; set; }
    }
}
