using Microsoft.AspNetCore.Mvc;

namespace FullFraim.Web.Controllers.ApiControllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("In API Controller!");
        }
    }
}
