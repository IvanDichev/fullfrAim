using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace FullFraim.Models.ViewModels.Enrolling
{
    public class EnrollViewModel
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int UserId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int ContestId { get; set; }

        [Required]
        public IFormFile Photo { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 3)]
        [Display(Name = "Image Description")]
        public string ImageDescription { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        [Display(Name = "Image Title")]
        public string ImageTitle { get; set; }
    }
}
