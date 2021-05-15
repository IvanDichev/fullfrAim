using FullFraim.Web.Configurations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FullFraim.Web.Controllers.ApiControllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IOptions<JwtSettings> options;

        public AccountController(IOptions<JwtSettings> options)
        {
            this.options = options;
        }

        [HttpGet("[action]")]
        public ActionResult<string> Login(string username, string password)
        {
            if(username == "admin" && password == "admin")
            {
                var secret = this.options.Value.Secret;
                var key = Encoding.UTF8.GetBytes(secret);

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Expires = DateTime.UtcNow.AddDays(7),
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Role, "Admin"),
                        new Claim(ClaimTypes.Name, "admin@fullfraimAPI.com"),
                        new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
                    }),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwt = tokenHandler.WriteToken(token);
                return jwt;
            }

            return this.Forbid();
        }
    }
}
