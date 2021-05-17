using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.AccountAPI;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shared;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FullFraim.Services.API_JwtServices
{
    public class JwtServices : IJwtServices
    {
        private readonly IOptions<JwtSettings> options;
        private readonly UserManager<User> userManager;

        public JwtServices(IOptions<JwtSettings> options,
            UserManager<User> userManager)
        {
            this.options = options;
            this.userManager = userManager;
        }

        public async Task<string> Login(string userName, string password)
        {
            User user = await userManager.FindByNameAsync(userName);

            if( user == null || 
                !await userManager.CheckPasswordAsync(user, password))
            {
                return null;
            }

            var secret = this.options.Value.Secret;
            var key = Encoding.UTF8.GetBytes(secret);

            var userRoles = await userManager.GetRolesAsync(user);

            var roleClaims = userRoles.Select(ur => new Claim(ClaimTypes.Role, ur));
            var authClaims = new List<Claim>(roleClaims)
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddMinutes(15),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
                    );

            var jwt = tokenHandler.WriteToken(token);
            return jwt;
        }

        public async Task<bool> Register(RegisterInputModel model)
        {
            var user = new User { UserName = model.Email, Email = model.Email };
            var result = await userManager.CreateAsync(user, model.Password);

            await this.userManager
                .AddToRoleAsync(user, Constants.RolesSeed.Participant);

            return result.Succeeded;
        }
    }
}
