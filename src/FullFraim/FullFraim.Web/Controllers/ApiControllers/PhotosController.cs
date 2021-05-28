﻿using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Pagination;
using FullFraim.Models.Dto_s.PhotoJunkies;
using FullFraim.Models.Dto_s.Photos;
using FullFraim.Services.ContestServices;
using FullFraim.Services.PhotoService;
using FullFraim.Services.SecurityServices;
using FullFraim.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Utilities.CloudinaryUtils;

namespace FullFraim.Web.Controllers.ApiControllers
{
    [ApiController]
    [APIExceptionFilter]
    [Route("api/[Controller]")]
    public class PhotosController : BaseApiController
    {
        private readonly IPhotoService photoService;
        private readonly IContestService contestService;

        public PhotosController(IPhotoService photoService,
            IContestService contestService,
            ISecurityService securityService)
            : base(securityService)
        {
            this.photoService = photoService;
            this.contestService = contestService;
        }

        /// <summary>
        /// Get photos for contest
        /// </summary>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedModel<PhotoDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAll(int contestId, [FromQuery] PaginationFilter paginationFilter)
        {
            if (contestId < 0)
            {
                return BadRequest();
            }

            if (!(await this.IsCurrentUserJuryInContestAsync(contestId) ||
                await this.IsCurrentUserParticipantInContestAsync(contestId)))
            {
                return Unauthorized();
            }

            var userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var photos = await this.photoService.GetPhotosForContestAsync(userId, contestId, paginationFilter);

            return Ok(photos);
        }

        [HttpGet("submissions")]
        [Authorize]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedModel<ContestSubmissionOutputDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllSubmissions(int contestId, [FromQuery] PaginationFilter paginationFilter)
        {
            if (contestId < 0)
            {
                return BadRequest();
            }

            if (!await this.contestService.IsContestInPhaseFinished(contestId) &&
                !await this.IsCurrentUserJuryInContestAsync(contestId))
            {
                var userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

                var userSubmission = await this.photoService.GetUserSubmissionForContestAsync(userId, contestId);

                return Ok(userSubmission);
            }

            if (!(await this.IsCurrentUserJuryInContestAsync(contestId) ||
                await this.IsCurrentUserParticipantInContestAsync(contestId)))
            {
                return Unauthorized();
            }

            var photos = await this.photoService
                .GetDetailedSubmissionsFromContest(contestId, paginationFilter);

            return Ok(photos);
        }

        [Authorize]
        [HttpGet("{id}")]
        [APIExceptionFilter]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PhotoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            // If you didn't submit the picture and you are not the admin
            var userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (!await this.photoService.IsPhotoSubmitedByUserAsync(userId, id) &&
                !await this.IsUserAdmin())
            {
                return Unauthorized();
            }

            var photos = await this.photoService.GetByIdAsync(id);

            return Ok(photos);
        }

        [HttpGet("TopRecent")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<PhotoDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTopRecent()
        {
            var photos = await this.photoService.GetTopRecentPhotos();

            return Ok(photos);
        }
    }
}
