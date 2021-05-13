using Microsoft.AspNetCore.Mvc;

namespace PhotoContest.Web.Controllers.ApiControllers
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
