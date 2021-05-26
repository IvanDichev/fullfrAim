using FullFraim.Models.Dto_s.PhotoJunkies;
using FullFraim.Services.PhotoJunkieServices;
using FullFraim.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Utilities.CloudinaryUtils;

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Enroll(InputEnrollForContestDto inputEnroll)
        {
            var userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            inputEnroll.UserId = userId;

            if (await this.photoJunkieService.CanJunkyEnroll(inputEnroll.ContestId, userId))
            {
                return BadRequest();
            }

            if (string.IsNullOrWhiteSpace(inputEnroll.ImageUrl) ||
                inputEnroll.Photo == null)
            {
                return BadRequest();
            }

            if (!string.IsNullOrWhiteSpace(inputEnroll.ImageUrl))
            {
                inputEnroll.ImageUrl = this.cloudinaryService.UploadImage(inputEnroll.Photo);
            }

            await this.photoJunkieService.EnrollForContestAsync(inputEnroll);

            return Ok();
        }
    }
}
