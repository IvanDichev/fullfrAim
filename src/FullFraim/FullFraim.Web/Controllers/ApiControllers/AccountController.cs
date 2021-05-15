using FullFraim.Services.API_JwtServices;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace FullFraim.Web.Controllers.ApiControllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IJwtServices jwtServices;

        public AccountController(IJwtServices jwtServices)
        {
            this.jwtServices = jwtServices;
        }

        [HttpGet("[action]")]
        public ActionResult<string> Login(string username, string password)
        {
            if(username == Constants.UserSeed.UserName 
                && password == Constants.UserSeed.Password)
            {
                return this.jwtServices.Login(username, password);
            }

            return this.Forbid();
        }
    }
}
