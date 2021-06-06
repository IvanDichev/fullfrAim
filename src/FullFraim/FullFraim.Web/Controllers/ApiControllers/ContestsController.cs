using FullFraim.Models.Dto_s.Contests;
using FullFraim.Models.Dto_s.Pagination;
using FullFraim.Services.ContestServices;
using FullFraim.Services.SecurityServices;
using FullFraim.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static Shared.Constants;

namespace FullFraim.Web.Controllers.ApiControllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ContestsController : BaseApiController
    {
        private readonly IContestService contestService;

        public ContestsController(IContestService contestService,
            ISecurityService securityService) :
            base(securityService)
        {
            this.contestService = contestService;
        }


        [HttpGet]
        [APIExceptionFilter]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedModel<OutputContestDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAll
            ([FromQuery] PaginationFilter paginationFilter, int? participantId, int? juryId, string phase, string contestType)
        {
            var contests = await this.contestService.GetAllAsync(participantId, juryId, phase, contestType, paginationFilter);

            return this.Ok(contests);
        }

        [HttpGet("{contestId}")]
        [APIExceptionFilter]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OutputContestDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int contestId)
        {
            if (!(await IsCurrentUserJuryInContestAsync(contestId) || await IsCurrentUserParticipantInContestAsync(contestId)))
            {
                return this.Unauthorized();
            }

            var contest = await this.contestService.GetByIdAsync(contestId);

            return this.Ok(contest);
        }

        [HttpPost]
        [Authorize(Roles = Roles.Organizer)]
        [APIExceptionFilter]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Create([FromBody] InputContestDto inputModel)
        {
            if (!await this.contestService.IsNameUniqueAsync(inputModel.Name))
            {
                return BadRequest("Name must be unique.");
            }

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
            if (!await IsCurrentUserJuryInContestAsync(id))
            {
                return this.Unauthorized();
            }

            await this.contestService.UpdateAsync(id, inputModel);

            return this.Ok();
        }

        [HttpDelete("{id}")]
        [APIExceptionFilter]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete([FromHeader] int id)
        {
            if (!await IsCurrentUserJuryInContestAsync(id))
            {
                return this.Unauthorized();
            }
            await this.contestService.DeleteAsync(id);

            return this.NoContent();
        }

        [HttpGet("/Covers")]
        [Authorize(Roles = Roles.Organizer)]
        [APIExceptionFilter]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedModel<string>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetCovers([FromQuery] PaginationFilter paginationFilter)
        {
            var result = await this.contestService.GetContestCoversAsync(paginationFilter);

            return this.Ok(result);
        }
    }
}
