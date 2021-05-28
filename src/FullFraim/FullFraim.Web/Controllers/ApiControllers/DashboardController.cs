using FullFraim.Services.PhotoService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
