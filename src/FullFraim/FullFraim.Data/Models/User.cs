﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FullFraim.Data.Models
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

        public ICollection<UserContest> UserContests { get; set; }

        public ICollection<Photo> Photos { get; set; }

        public ICollection<PhotoReview> PhotoReviews { get; set; }
    }
}
