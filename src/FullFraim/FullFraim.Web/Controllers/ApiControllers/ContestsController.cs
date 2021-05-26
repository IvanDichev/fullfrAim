﻿using FullFraim.Models.Dto_s.Contests;
using FullFraim.Services.ContestServices;
using FullFraim.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
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
        private readonly ILogger<PhotosController> logger;

        public ContestsController(IContestService contestService, ILogger<PhotosController> logger)
        {
            this.contestService = contestService;
            this.logger = logger;
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

        [HttpPost]
        [Authorize(Roles = RolesSeed.Organizer)]
        [APIExceptionFilter]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Create([FromBody] InputContestDto inputModel) 
        {
            await this.contestService.CreateAsync(inputModel);

            return this.Ok();
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

                return this.Ok();
            }

            return this.Unauthorized();
        }

        [HttpGet("/Covers")]
        [Authorize(Roles = RolesSeed.Organizer)]
        [APIExceptionFilter]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<string>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetCovers()                               
        {
            var result = await this.contestService.GetCoversAsync();

            return this.Ok(result);
        }

        [HttpGet("/Open")]
        [APIExceptionFilter]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<OutputContestDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetContestsInPhaseOne()                    // TODO: Add PaginationFilter
        { 
            int userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var contests = await this.contestService.GetContestsInPhaseOneAsync(userId);

            return this.Ok(contests);
        }

        [HttpGet("/Closed")]
        [APIExceptionFilter]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<OutputContestDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetContestsInPhaseTwo()                    // TODO: Add PaginationFilter
        {
            int userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var contests = await this.contestService.GetContestsInPhaseTwoAsync(userId);

            return this.Ok(contests);
        }

        [HttpGet("/Finished")]
        [APIExceptionFilter]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<OutputContestDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetContestsInPhaseFinished()                    // TODO: Add PaginationFilter
        {
            int userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var contests = await this.contestService.GetContestsInPhaseFinishedAsync(userId);

            return this.Ok(contests);
        }
    }
}
