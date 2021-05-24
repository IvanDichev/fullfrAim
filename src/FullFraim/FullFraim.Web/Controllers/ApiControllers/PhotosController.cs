using FullFraim.Models.Dto_s.Pagination;
using FullFraim.Models.Dto_s.Photos;
using FullFraim.Services.PhotoService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FullFraim.Web.Controllers.ApiControllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PhotosController : BaseApiController
    {
        private readonly IPhotoService photoService;

        public PhotosController(IPhotoService photoService)
        {
            this.photoService = photoService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedModel<PhotoDto>))]
        public async Task<IActionResult> GetAll(int contestId,[FromQuery] PaginationFilter paginationFilter)
        {
            var photos = await this.photoService.GetPhotosForContestAsync(contestId, paginationFilter);

            return Ok(photos);
        }
    }
}
