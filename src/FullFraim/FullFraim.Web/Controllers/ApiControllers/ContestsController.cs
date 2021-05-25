using FullFraim.Models.Dto_s.Contests;
using FullFraim.Services.ContestServices;
using FullFraim.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FullFraim.Web.Controllers.ApiControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContestsController : BaseApiController
    {
        private readonly IContestService contestService;

        public ContestsController(IContestService contestService)
        {
            this.contestService = contestService;
        }


        [HttpGet]
        [APIExceptionFilter]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<OutputContestDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAll()                       // TODO: Add PaginationFilter                    
        {
            int userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var contests = await this.contestService.GetAllAsync(userId);

            return this.Ok(contests);
        }

        [HttpGet("{id}")]
        [APIExceptionFilter]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OutputContestDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetById(int contestId)         // TODO: Add PaginationFilter
        {
            if (await IsCurrentUserJuryInContestAsync(contestId) || await IsCurrentUserParticipantInContestAsync(contestId))
            {
                var contest = await this.contestService.GetByIdAsync(contestId);
                return this.Ok(contest);
            }

            return this.Unauthorized();
        }
    }
}
