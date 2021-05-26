using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullFraim.Models.Dto_s.PhotoJunkies
{
    public class InputEnrollForContestDto
    {
        [NotMapped]
        [Range(0, int.MaxValue)]
        public int UserId { get; set; }

        [Range(0, int.MaxValue)]
        public int ContestId { get; set; }

        public string ImageUrl { get; set; }

        public IFormFile Photo { get; set; }

        [StringLength(maximumLength: 2000)]
        public string ImageDescription { get; set; }

        [StringLength(maximumLength: 20)]
        public string ImageTitle { get; set; }
    }
}
