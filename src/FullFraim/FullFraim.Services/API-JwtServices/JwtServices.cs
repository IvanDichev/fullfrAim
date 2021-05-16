using FullFraim.Data.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FullFraim.Services.API_JwtServices
{
    public class JwtServices : IJwtServices
    {
        private readonly IOptions<JwtSettings> options;

        public JwtServices(IOptions<JwtSettings> options)
        {
            this.options = options;
        }

        public string Login(string UserName, ICollection<string> roles)
        {
            var secret = this.options.Value.Secret;
            var key = Encoding.UTF8.GetBytes(secret);

            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            foreach (var claims in roles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, claims));
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
                    );

            var jwt = tokenHandler.WriteToken(token);
            return jwt;
        }
    }
}
