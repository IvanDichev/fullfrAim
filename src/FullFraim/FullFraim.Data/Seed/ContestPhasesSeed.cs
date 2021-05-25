using FullFraim.Data.Models;
using System;
using System.Collections.Generic;

namespace FullFraim.Data.Seed
{
    public class ContestPhasesSeed
    {
        public static readonly List<ContestPhase> SeedData = new List<ContestPhase>()
        {
            // Contest PhaseOne
            new ContestPhase()
            {
                ContestId = 1,
                PhaseId = 1,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(30),
            },
            new ContestPhase()
            {
                ContestId = 1,
                PhaseId = 2,
                StartDate = DateTime.UtcNow.AddDays(30),
                EndDate = DateTime.UtcNow.AddDays(60),
            },
            new ContestPhase()
            {
                ContestId = 1,
                PhaseId = 3,
                StartDate = DateTime.UtcNow.AddDays(60),
                EndDate = DateTime.UtcNow.AddDays(900),
            },
            // Contest PhaseTwo
            new ContestPhase()
            {
                ContestId = 2,
                PhaseId = 1,
                StartDate = DateTime.UtcNow.AddDays(-30),
                EndDate = DateTime.UtcNow,
            },
            new ContestPhase()
            {
                ContestId = 2,
                PhaseId = 2,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(30),
            },
            new ContestPhase()
            {
                ContestId = 2,
                PhaseId = 3,
                StartDate = DateTime.UtcNow.AddDays(30),
                EndDate = DateTime.UtcNow.AddDays(600),
            },
            // Contest PhaseThree
            new ContestPhase()
            {
                ContestId = 3,
                PhaseId = 1,
                StartDate = DateTime.UtcNow.AddDays(-2),
                EndDate = DateTime.UtcNow.AddDays(-1),
            },
            new ContestPhase()
            {
                ContestId = 3,
                PhaseId = 2,
                StartDate = DateTime.UtcNow.AddDays(-1),
                EndDate = DateTime.UtcNow,
            },
            new ContestPhase()
            {
                ContestId = 3,
                PhaseId = 3,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(300),
            },
            new ContestPhase()
            {
                ContestId = 4,
                PhaseId = 1,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(30),
            },
            new ContestPhase()
            {
                ContestId = 4,
                PhaseId = 2,
                StartDate = DateTime.UtcNow.AddDays(30),
                EndDate = DateTime.UtcNow.AddDays(60),
            },
            new ContestPhase()
            {
                ContestId = 4,
                PhaseId = 3,
                StartDate = DateTime.UtcNow.AddDays(60),
                EndDate = DateTime.UtcNow.AddDays(300),
            },

        };
    }
}
