using FullFraim.Models.Dto_s.PhotoJunkies;
using FullFraim.Services.PhotoJunkieServices;
using FullFraim.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities.CloudinaryUtils;
using Utilities.Mapper;

namespace FullFraim.Web.Controllers.ApiControllers
{
    [Authorize]
    [ApiController]
    [APIExceptionFilter]
    [Route("api/[controller]")]
    public class JunkiesController : ControllerBase
    {
        private readonly IPhotoJunkieService photoJunkieService;
        private readonly ICloudinaryService cloudinaryService;

        public JunkiesController(IPhotoJunkieService photoJunkieService,
            ICloudinaryService cloudinaryService)
        {
            this.photoJunkieService = photoJunkieService;
            this.cloudinaryService = cloudinaryService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<PhotoJunkyDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAll()
        {
            var junkies = await this.photoJunkieService.GetAllAsync();

            return Ok(junkies);
        }

        [HttpPost("enroll")]
        [IgnoreAntiforgeryToken]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Enroll([FromForm] InpurEnrollForContestModel inputModel)
        {
            if (!await this.photoJunkieService.CanJunkyEnroll(inputModel.ContestId, inputModel.UserId))
            {
                return BadRequest(error: $"User with id: {inputModel.UserId} already in contest with id: {inputModel.ContestId}!");
            }
            var inputDto = inputModel.MapToDto();

            inputDto.PhotoUrl = this.cloudinaryService.UploadImage(inputModel.Photo);

            await this.photoJunkieService.EnrollForContestAsync(inputDto);

            return Ok();
        }

        [HttpGet("nextrank")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PhotoJunkyDto))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPointsTillNextRank([FromQuery] int userId)
        {
            if (userId < 0)
            {
                return BadRequest();
            }

            var junkieTillNextRankDto = await this.photoJunkieService.GetPointsTillNextRankAsync(userId);

            return Ok(junkieTillNextRankDto);
        }
    }
}
