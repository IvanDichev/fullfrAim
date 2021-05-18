using FullFraim.Data.Base;
using System;

namespace FullFraim.Data.Models
{
    public class ContestPhase : DeletableEntity<int>
    {
        public int ContestId { get; set; }
        public Contest Contest { get; set; }

        public int PhaseId { get; set; }
        public Phase Phase { get; set; }

        public DateTime PhaseEndDate { get; set; }
    }
}
