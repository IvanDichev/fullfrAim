using FullFraim.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FullFraim.Services.SecurityServices
{
    public class SecurityService : ISecurityService
    {
        private readonly FullFraimDbContext context;

        public SecurityService(FullFraimDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> IsUserJuryInContest(int userId, int contestId)
        {
            return await this.context.JuryContests
                .AnyAsync(jc => jc.UserId == userId && jc.ContestId == contestId);
        }
    }
}
