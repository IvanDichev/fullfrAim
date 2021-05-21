using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.ContestCategories;
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
        public DateTime PhaseI_Time { get; set; }
        public DateTime PhaseII_Time { get; set; }
        public DateTime PhaseIII_Time { get; set; }
        public string ContestCategory { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<DashboardViewModel> Contests { get; set; }
        public IEnumerable<ContestCategoryDto> Categories { get; set; }
    }
}
