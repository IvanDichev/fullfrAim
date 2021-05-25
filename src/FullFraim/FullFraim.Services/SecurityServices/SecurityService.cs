using FullFraim.Data;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> IsUserJuryInContestAsync(int userId, int contestId)
        {
            return await this.context.JuryContests
                .AnyAsync(jc => jc.UserId == userId && jc.ContestId == contestId);
        }

        public async Task<bool> IsUserParticipantInContestAsync(int userId, int contestId)
        {
            return await this.context.ParticipantContests
                .AnyAsync(pc => pc.UserId == userId && pc.ContestId == contestId);
        }
    }
}
