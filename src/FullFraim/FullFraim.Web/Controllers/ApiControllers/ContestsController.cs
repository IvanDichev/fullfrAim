using FullFraim.Models.Dto_s.Contests;
using FullFraim.Models.Dto_s.Pagination;
using FullFraim.Services.ContestServices;
using FullFraim.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using static Shared.Constants;

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedModel<OutputContestDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter paginationFilter)                                           
        {
            int userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var contests = await this.contestService.GetAllAsync(userId, paginationFilter);

            return this.Ok(contests);
        }

        [HttpGet("{id}")]
        [APIExceptionFilter]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OutputContestDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int contestId)         
        {
            if (await IsCurrentUserJuryInContestAsync(contestId) || await IsCurrentUserParticipantInContestAsync(contestId))
            {
                var contest = await this.contestService.GetByIdAsync(contestId);
                return this.Ok(contest);
            }

            return this.Unauthorized();
        }

        [HttpPost]
        [Authorize(Roles = RolesSeed.Organizer)]
        [APIExceptionFilter]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Create([FromBody] InputContestDto inputModel) 
        {
            var createdModel = await this.contestService.CreateAsync(inputModel);

            return this.Created(nameof(GetById), createdModel);
        }

        [HttpPut("{id}")]
        [APIExceptionFilter]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromHeader] int id, [FromBody] InputContestDto inputModel)
        {
            if (await IsCurrentUserJuryInContestAsync(id))
            {
                await this.contestService.UpdateAsync(id, inputModel);

                return this.Ok();
            }

            return this.Unauthorized();
        }

        [HttpDelete("{id}")]
        [APIExceptionFilter]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete([FromHeader] int id)
        {
            if (await IsCurrentUserJuryInContestAsync(id))
            {
                await this.contestService.DeleteAsync(id);

                return this.NoContent();
            }

            return this.Unauthorized();
        }

        [HttpGet("/Covers")]
        [Authorize(Roles = RolesSeed.Organizer)]
        [APIExceptionFilter]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedModel<string>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetCovers([FromQuery] PaginationFilter paginationFilter)                               
        {
            var result = await this.contestService.GetCoversAsync(paginationFilter);

            return this.Ok(result);
        }

        [HttpGet("/PhaseOne")]
        [APIExceptionFilter]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedModel<OutputContestDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetContestsInPhaseOne([FromQuery] PaginationFilter paginationFilter)                   
        { 
            int userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var contests = await this.contestService.GetContestsInPhaseOneAsync(userId, paginationFilter);

            return this.Ok(contests);
        }

        [HttpGet("/PhaseTwo")]
        [APIExceptionFilter]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedModel<OutputContestDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetContestsInPhaseTwo([FromQuery] PaginationFilter paginationFilter)                    
        {
            int userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var contests = await this.contestService.GetContestsInPhaseTwoAsync(userId, paginationFilter);

            return this.Ok(contests);
        }

        [HttpGet("/Finished")]
        [APIExceptionFilter]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedModel<OutputContestDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetContestsInPhaseFinished([FromQuery] PaginationFilter paginationFilter)                    
        {
            int userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var contests = await this.contestService.GetContestsInPhaseFinishedAsync(userId, paginationFilter);

            return this.Ok(contests);
        }
    }
}
