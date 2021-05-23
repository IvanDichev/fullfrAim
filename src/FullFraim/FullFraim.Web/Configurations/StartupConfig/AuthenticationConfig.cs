using FullFraim.Data;
using FullFraim.Data.Models;
using FullFraim.Services.API_JwtServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
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

        public static void SingInConfiguration(IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole<int>>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.SignIn.RequireConfirmedEmail = true;

                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

                options.User.RequireUniqueEmail = true;
            })
                    .AddEntityFrameworkStores<FullFraimDbContext>()
                    .AddDefaultTokenProviders();
        }
    }
}
