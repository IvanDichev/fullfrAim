using FullFraim.Data.Models;
using Shared;
using System;
using System.Linq.Expressions;

namespace FullFraim.Services.Delegates
{
    public static class FiltrationDelegates
    {
        public static Func<ContestPhase, bool> IsFinishedPhase =>
            cp => cp.Phase.Name == Constants.PhasesSeed.Finished &&
                    cp.StartDate < DateTime.UtcNow;
        
        public static Func<ContestPhase, bool> IsPhaseTwo =>
            cp => cp.Phase.Name == Constants.PhasesSeed.PhaseII &&
                    cp.EndDate > DateTime.UtcNow && cp.StartDate < DateTime.UtcNow;

        public static Func<ContestPhase, bool> IsPhaseOne =>
            cp => cp.Phase.Name == Constants.PhasesSeed.PhaseI &&
                    cp.EndDate > DateTime.UtcNow;
    }
}
