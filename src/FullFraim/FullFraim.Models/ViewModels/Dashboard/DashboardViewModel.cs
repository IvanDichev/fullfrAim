using FullFraim.Models.Dto_s.ContestCategories;
using FullFraim.Models.Dto_s.Phases;
using System;
using System.Collections.Generic;

namespace FullFraim.Models.ViewModels.Dashboard
{
    public class DashboardViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cover_Url { get; set; }
        public string Description { get; set; }
        public PhaseDto ActivePhase { get; set; }
        public int ContestCategory { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCurrentUserParticipant { get; set; }
        public bool IsCurrentUserJury { get; set; }
        public IEnumerable<DashboardViewModel> Contests { get; set; }
        // TODO MAKE VIEW MODEL
        public IEnumerable<ContestCategoryDto> Categories { get; set; }
    }
}
