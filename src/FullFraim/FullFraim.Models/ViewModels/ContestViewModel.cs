using System;
using System.ComponentModel.DataAnnotations;

namespace FullFraim.Models.ViewModels
{
    public class ContestViewModel
    {
        public int Id { get; set; } // Do we need to make validations in the view model?

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
        public DateTime PhaseI_Time { get; set; }

        [Required]
        public DateTime PhaseII_Time { get; set; }

        [Required]
        public DateTime PhaseIII_Time { get; set; }

        [Required]
        [Display(Name = "Contest Category")]
        public int ContestCategoryId { get; set; }

        [Required]
        [Display(Name = "Contest Type")]
        public int ContestTypeId { get; set; }
    }
}
