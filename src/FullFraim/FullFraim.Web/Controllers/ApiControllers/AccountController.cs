using FullFraim.Models.Dto_s.AccountAPI;
using FullFraim.Services.API_JwtServices;
using FullFraim.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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

        [HttpGet()]
        public async Task<IActionResult> Login([FromBody] InputLoginModel_API model)
        {
            var result = await this.jwtServices.Login(model);

            if (result != null)
            {
                return Ok(result);
            }

            return Unauthorized();
        }

        [HttpPost("[action]")]
        [ServiceFilter(typeof(APIExceptionFilter))]
        public async Task<IActionResult> Register([FromBody] RegisterInputModel_API model)
        {
            if (ModelState.IsValid)
            {
                var result = await this.jwtServices.Register(model);

                if (result == true)
                {
                    return Ok("Registered");
                }
            }

            return BadRequest();
        }
    }
}
