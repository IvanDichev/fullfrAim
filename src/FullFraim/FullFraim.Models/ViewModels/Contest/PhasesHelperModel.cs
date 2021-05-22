using System;
using System.ComponentModel.DataAnnotations;

namespace FullFraim.Models.ViewModels.Contest
{
    public class PhasesHelperModel
    {
        public DateTime StartDate_PhaseI { get; set; }

        [Display(Name = "End Date of Phase I")]
        public DateTime EndDate_PhaseI { get; set; }


        public DateTime StartDate_PhaseII { get; set; }

        [Display(Name = "End Date of Phase II")]
        public DateTime EndDate_PhaseII { get; set; }


        public DateTime StartDate_PhaseIII { get; set; }
        public DateTime EndDate_PhaseIII { get; set; }
    }
}
