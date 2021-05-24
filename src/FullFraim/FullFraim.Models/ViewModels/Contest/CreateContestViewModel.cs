using FullFraim.Models.ViewModels.Contest;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FullFraim.Models.Contest.ViewModels
{
    public class CreateContestViewModel
    {
        public int Id { get; set; } // Do we need to make validations in the view model?

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Cover")]
        public IFormFile Cover { get; set; }

        public string Cover_Url { get; set; }

        [Required]
        [Display(Name = "Decription")]
        public string Description { get; set; }

        public PhasesHelperModel Phases { get; set; }

        [Required]
        [Display(Name = "Contest Category")]
        public int ContestCategoryId { get; set; }

        [Required]
        [Display(Name = "Contest Type")]
        public int ContestTypeId { get; set; }
    }
}
