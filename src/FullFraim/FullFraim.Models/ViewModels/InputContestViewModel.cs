using System.ComponentModel.DataAnnotations;

namespace FullFraim.Models.ViewModels
{
    public class InputContestViewModel
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
        public string Phase { get; set; }

        [Required]
        [Display(Name = "Contest Category")]
        public string ContestCategory { get; set; }

        [Required]
        [Display(Name = "Contest Type")]
        public string ContestType { get; set; }
    }
}
