using FullFraim.Data;
using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Contests;
using System;
using System.Threading.Tasks;

namespace FullFraim.Services.ContestServices
{
    public class ContestService : IContestService
    {
        private readonly FullFraimDbContext context;

        public ContestService(FullFraimDbContext context)
        {
            this.context = context;
        }

        public async Task<InputContestModel> Create(InputContestModel model)
        {
            if(model == null)
            {
                throw new ArgumentNullException();
            }

            var contest = new Contest()
            {
                Name = model.Name,
                Cover_Url = model.Cover_Url,
                Description = model.Description,
                CreatedOn = DateTime.UtcNow,
                ContestCategoryId = model.ContestCategoryId,
                PhaseId = model.PhaseId,
                ContestTypeId = model.ContestTypeId
            };

            await this.context.Contests.AddAsync(contest);

            await this.context.SaveChangesAsync();

            return model;
        }
    }
}
