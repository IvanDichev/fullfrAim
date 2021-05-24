﻿using FullFraim.Models.Dto_s.Pagination;
using FullFraim.Models.Dto_s.Photos;
using FullFraim.Services.Exceptions;
using FullFraim.Services.PhotoService;
using FullFraim.Web.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace FullFraim.Web.Controllers.ApiControllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PhotosController : BaseApiController
    {
        private readonly IPhotoService photoService;
        private readonly ILogger<PhotosController> logger;

        public PhotosController(IPhotoService photoService,
            ILogger<PhotosController> logger)
        {
            this.photoService = photoService;
            this.logger = logger;
        }

        [HttpGet]
        [APIExceptionFilter]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedModel<PhotoDto>))]
        public async Task<IActionResult> GetAll(int contestId,[FromQuery] PaginationFilter paginationFilter)
        {
            var photos = await this.photoService.GetPhotosForContestAsync(contestId, paginationFilter);

            return Ok(photos);
        }
    }
}
