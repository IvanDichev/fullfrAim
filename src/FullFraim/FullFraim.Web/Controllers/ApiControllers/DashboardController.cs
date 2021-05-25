using FullFraim.Services.PhotoService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FullFraim.Web.Controllers.ApiControllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
