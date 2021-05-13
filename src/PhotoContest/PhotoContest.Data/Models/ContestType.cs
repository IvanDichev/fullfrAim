using PhotoContest.Data.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoContest.Data.Models
{
    public class ContestType : DeletableEntity<int>
    {
        public string Name { get; set; }
        public ICollection<Contest> Contests { get; set; }
    }
}
