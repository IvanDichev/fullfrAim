using FullFraim.Models.Dto_s.Reviews;
using FullFraim.Services.JuryServices;
using FullFraim.Web.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FullFraim.Web.Controllers.ApiControllers
{
    [Authorize]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [APIExceptionFilter]
    [Route("api/[controller]")]
    public class JuriesController : Controller
    {
        private readonly IJuryService juryService;

        public JuriesController(IJuryService juryService)
        {
            this.juryService = juryService;
        }


        [HttpPost("review")]
        [IgnoreAntiforgeryToken]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GiveReview([FromBody] InputGiveReviewDto inputModel)
        {
            var juryId = inputModel.JuryId;
            var photoId = inputModel.PhotoId;

            if (!await juryService.IsContestInPhaseTwoAsync(photoId))
            {
                return BadRequest(new { ErrorMsg = "Rewiev option not available outside Phase Two." });
            }

            if (await juryService.HasJuryAlreadyGivenReviewAsync(juryId, photoId))
            {
                return BadRequest(new { ErrorMsg = "The photo has already been reviewed." });
            }

            var toAddReview = await this.juryService.GiveReviewAsync(inputModel);

            return Ok(toAddReview);
        }
    }
}
