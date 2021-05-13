using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhotoContest.Data.Models
{
    public class User : IdentityUser<int>
    {
        //Vanka: how to implement soft delete for the user since we cannot inherit from the base entities
        [Required]
        [StringLength(maximumLength: 20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(maximumLength: 20)]
        public string LastName { get; set; }

        public uint Points { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }

        public int UserContestId { get; set; }
        public UserContest UserContest { get; set; }

        public ICollection<Photo> Photos { get; set; }
    }
}
