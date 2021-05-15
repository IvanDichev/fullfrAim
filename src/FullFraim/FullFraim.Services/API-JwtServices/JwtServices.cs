using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shared;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FullFraim.Services.API_JwtServices
{
    public class JwtServices : IJwtServices
    {
        private readonly IOptions<JwtSettings> options;
        private readonly IConfiguration configuration;

        public JwtServices(IOptions<JwtSettings> options, IConfiguration configuration)
        {
            this.options = options;
            this.configuration = configuration;
        }

        public string Login(string username, string password)
        {
            var secret = this.options.Value.Secret;
            var key = Encoding.UTF8.GetBytes(secret);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(7),
                Subject = new ClaimsIdentity(new[]
                {
                        new Claim(ClaimTypes.Role, Constants.RolesSeed.Admin),
                        new Claim(ClaimTypes.Name, this.configuration["AccountAdminInfo:Email"]),
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
    }
}
