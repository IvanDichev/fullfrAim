using System;
using System.Collections.Generic;

namespace FullFraim.Models.ViewModels.Dashboard
{
    public class DashboardViewModel
    {
        public string Name { get; set; }
        public string Cover_Url { get; set; }
        public string Description { get; set; }
        public string Phase { get; set; }
        public string ContestCategory { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<ContestViewModel> Contests { get; set; }
    }
}
