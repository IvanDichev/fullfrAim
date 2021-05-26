using FullFraim.Data.Models;
using FullFraim.Services.SecurityServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FullFraim.Web.Controllers.ApiControllers
{
    [ApiController]
    public abstract class BaseApiController : ControllerBase
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
        
        protected internal async Task<bool> IsUserAdmin()
        {
            var userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            return await this.securityService.IsUserAdmin(userId);
        }
    }
}
