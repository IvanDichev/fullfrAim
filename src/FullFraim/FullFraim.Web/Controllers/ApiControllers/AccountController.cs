using FullFraim.Services.API_JwtServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Shared;

namespace FullFraim.Web.Controllers.ApiControllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IJwtServices jwtServices;
        private readonly IConfiguration configuration;

        public AccountController(IJwtServices jwtServices, IConfiguration configuration)
        {
            this.jwtServices = jwtServices;
            this.configuration = configuration;
        }

        [HttpGet("[action]")]
        public ActionResult<string> Login(string username, string password)
        {
            if (username == configuration["AccountAdminInfo:UserName"] 
                && password == configuration["AccountAdminInfo:Password"])
            {
                return this.jwtServices.Login(username, password);
            }

            return this.Forbid();
        }
    }
}
