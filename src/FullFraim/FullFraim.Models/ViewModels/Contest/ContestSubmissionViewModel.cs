using FullFraim.Models.Dto_s.Phases;
using FullFraim.Models.Dto_s.Reviews;
using System.Collections.Generic;

namespace FullFraim.Models.ViewModels.Contest
{
    public class ContestSubmissionViewModel
    {
        public int Id { get; set; }
        public string Image_Url { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public double Score { get; set; }
        public PhaseDto ActivePhase { get; set; }
        public IEnumerable<ReviewDto> Reviews { get; set; }
    }
}
