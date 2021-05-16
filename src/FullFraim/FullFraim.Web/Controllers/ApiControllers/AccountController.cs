using FullFraim.Data.Models;
using FullFraim.Services.API_JwtServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shared;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FullFraim.Web.Controllers.ApiControllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IJwtServices jwtServices;
        private readonly IConfiguration configuration;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public AccountController(IJwtServices jwtServices, 
            IConfiguration configuration, SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            this.jwtServices = jwtServices;
            this.configuration = configuration;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Login(string UserName, string Password)
        {
            User user = await userManager.FindByNameAsync(UserName);
            if (user != null && await userManager.CheckPasswordAsync(user, Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var jwt = this.jwtServices.Login(user.UserName, userRoles);

                return Ok(jwt);
            }
            return Unauthorized();
        }

        [HttpGet]
        public ActionResult WhoAmI()
        {
            return Ok("UserName" + this.User.Identity.Name);
        }
    }
}
