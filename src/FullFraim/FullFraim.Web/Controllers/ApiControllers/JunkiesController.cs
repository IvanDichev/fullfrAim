using FullFraim.Services.PhotoJunkieServices;
using FullFraim.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FullFraim.Web.Controllers.ApiControllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class JunkiesController : ControllerBase
    {
        private readonly IPhotoJunkieService photoJunkieService;

        public JunkiesController(IPhotoJunkieService photoJunkieService)
        {
            this.photoJunkieService = photoJunkieService;
        }

        [HttpGet]
        [APIExceptionFilter]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var junkies = await this.photoJunkieService.GetAllAsync();
            var v = junkies.Select(x => new
            {
                name = x.FirstName + x.LastName,
                points = x.Points,
            });

            return Ok(v);
        }
    }
}
