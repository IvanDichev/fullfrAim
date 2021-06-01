using FullFraim.Services.SecurityServices;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FullFraim.Web.Controllers
{
    public abstract class BaseMvcController : Controller
    {
        private readonly ISecurityService securityService;

        public BaseMvcController()
        {
        }

        public BaseMvcController(ISecurityService securityService)
        {
            this.securityService = securityService;
        }

        public int UserId { get => int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value); }

        protected internal async Task<bool> IsCurrentUserJuryInContestAsync(int contestId)
        {
            var userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            return await this.securityService.IsUserJuryInContestAsync(userId, contestId);
        }

        protected internal async Task<bool> IsCurrentUserParticipantInContestAsync(int contestId)
        {
            var userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            return await this.securityService.IsUserParticipantInContestAsync(userId, contestId);
        }
    }
}
