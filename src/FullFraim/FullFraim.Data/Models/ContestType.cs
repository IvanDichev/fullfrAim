using FullFraim.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FullFraim.Data.Models
{
    public class ContestType : DeletableEntity<int>
    {
        [Required]
        public string Name { get; set; }

        public ICollection<Contest> Contests { get; set; }
    }
}
