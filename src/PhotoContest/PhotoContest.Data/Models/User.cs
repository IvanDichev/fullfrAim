using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PhotoContest.Data.Models
{
    public class User : IdentityUser<int>
    {
        [Required]
        [StringLength(maximumLength: 20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(maximumLength: 20)]
        public string LastName { get; set; }

        public uint Points { get; set; }


    }
}
