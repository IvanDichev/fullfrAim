using FullFraim.Services.API_JwtServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FullFraim.Web.Configurations.StartupConfig
{
    public static class AuthenticationConfig
    {
        public static void ConfigureWith_Jwt(IServiceCollection services, 
            IConfiguration configuration)
        {
            var jwtSettingsSection = configuration
                .GetSection("JwtSettings");

            services.Configure<JwtSettings>(jwtSettingsSection);

            var settings = jwtSettingsSection.Get<JwtSettings>();

            var key = Encoding.UTF8.GetBytes(settings.Secret);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            ).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}
