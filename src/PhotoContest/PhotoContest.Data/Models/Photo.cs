using PhotoContest.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhotoContest.Data.Models
{
    public class Photo : DeletableEntity<int>
    {
        [Required]
        [StringLength(maximumLength: 20)]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ContestId { get; set; }
        public Contest Contest { get; set; }

        public ICollection<PhotoReview> PhotoReviews { get; set; }
    }
}
