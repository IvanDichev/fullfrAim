using FullFraim.Services.SecurityServices;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FullFraim.Web.Controllers.ApiControllers
{
    public abstract class BaseApiController : Controller
    {
        private readonly ISecurityService securityService;

        public BaseApiController()
        {
        }

        public BaseApiController(ISecurityService securityService)
        {
            this.securityService = securityService;
        }

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
