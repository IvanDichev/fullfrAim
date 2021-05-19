using FullFraim.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FullFraim.Data.Models
{
    public class Photo : DeletableEntity<int>
    {
        [Required]
        [StringLength(maximumLength: 20)]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        [StringLength(maximumLength: 20)] // TODO: Put minimum length?
        public string Description { get; set; }

        public ParticipantContest Participant { get; set; }

        public ICollection<PhotoReview> PhotoReviews { get; set; }
    }
}
