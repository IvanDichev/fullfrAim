using FullFraim.Data;
using FullFraim.Models.Dto_s.Scorings;
using System;
using System.Threading.Tasks;

namespace FullFraim.Services.ScoringServices
{
    public class ScoringService : IScoringService
    {
        private readonly FullFraimDbContext context;

        public ScoringService(FullFraimDbContext context)
        {
            this.context = context;
        }
        public Task CalculateScoring(InputScoringDto inputModel)
        {
            throw new NotImplementedException();
        }

       
    }
}
