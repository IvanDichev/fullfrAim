using FullFraim.Models.Dto_s.ContestCategories;
using FullFraim.Models.Dto_s.ContestTypes;
using FullFraim.Models.Dto_s.Phases;
using System.ComponentModel.DataAnnotations;

namespace FullFraim.Models.ViewModels
{
    public class ContestViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Cover_Url")]
        public string Cover_Url { get; set; }

        [Required]
        [Display(Name = "Decription")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Phase")]
        public int PhaseId { get; set; }

        [Required]
        [Display(Name = "Contest Category")]
        public int ContestCategoryId { get; set; }

        [Required]
        [Display(Name = "Contest Type")]
        public int ContestTypeId { get; set; }
    }
}
