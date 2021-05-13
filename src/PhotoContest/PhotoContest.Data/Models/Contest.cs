using PhotoContest.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhotoContest.Data.Models
{
    public class Contest : DeletableEntity<int>
    {
        [Required]
        [StringLength(maximumLength: 20)]
        public string Name { get; set; }

        //TODO: Implement Image_URL

        public string Description { get; set; }

        public int PhaseId { get; set; }
        public Phase Phase { get; set; }

        public int ContestCategoryId { get; set; }
        public ContestCategory ContestCategory { get; set; }

        public int ContestTypeId { get; set; }
        public ContestType ContestType { get; set; }

        public int UserContestId { get; set; }
        public UserContest UserContest { get; set; }

        public ICollection<Photo> Photos { get; set; }
    }
}
