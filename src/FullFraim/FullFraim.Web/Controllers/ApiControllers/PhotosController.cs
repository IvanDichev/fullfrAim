﻿using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Pagination;
using FullFraim.Models.Dto_s.PhotoJunkies;
using FullFraim.Models.Dto_s.Photos;
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
    [Authorize]
    [ApiController]
    [APIExceptionFilter]
    [Route("api/[Controller]")]
    public class PhotosController : BaseApiController
    {
        private readonly IPhotoService photoService;
        private readonly ILogger<PhotosController> logger;
        private readonly ICloudinaryService cloudinaryService;

        public PhotosController(IPhotoService photoService,
            ILogger<PhotosController> logger,
            ISecurityService securityService,
            ICloudinaryService cloudinaryService)
            : base(securityService)
        {
            this.photoService = photoService;
            this.logger = logger;
            this.cloudinaryService = cloudinaryService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedModel<PhotoDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAll(int contestId, [FromQuery] PaginationFilter paginationFilter)
        {
            if (contestId < 0)
            {
                return BadRequest();
            }

            if (await this.IsCurrentUserJuryInContestAsync(contestId) ||
                await this.IsCurrentUserParticipantInContestAsync(contestId))
            {
                return Unauthorized();
            }

            var photos = await this.photoService.GetPhotosForContestAsync(contestId, paginationFilter);

            return Ok(photos);
        }

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


        //[HttpPost]
        //[IgnoreAntiforgeryToken]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> UploadForContest(InputEnrollForContestDto inputModel)
        //{
        //    var result = this.cloudinaryService.UploadImage(inputModel.Photo);

        //    return Ok(new { Url = result });
        //}
    }
}
