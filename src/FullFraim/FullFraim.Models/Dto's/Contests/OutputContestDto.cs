﻿using FullFraim.Models.Dto_s.Phases;
using System;
using System.Collections.Generic;
using System.Text;

namespace FullFraim.Models.Dto_s.Contests
{
    public class OutputContestDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Cover_Url { get; set; }

        public string Description { get; set; }

        public int PhaseId { get; set; }

        public PhaseDto ActivePhase
        {
            get
            {
                foreach (var phase in PhasesInfo)
                {
                    if(phase.IsActive)
                    {
                        return phase;
                    }
                }

                return null;
            }
        }

        public ICollection<PhaseDto> PhasesInfo { get; set; }

        public int ContestCategoryId { get; set; }

        public int ContestTypeId { get; set; }
    }
}
