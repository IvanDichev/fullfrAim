using FullFraim.Services.PhotoService;
using Microsoft.AspNetCore.Mvc;

namespace FullFraim.Web.Controllers.ApiControllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IPhotoService photoService;

        public DashboardController(IPhotoService photoService)
        {
            this.photoService = photoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
