using FullFraim.Data;
using FullFraim.Services.API_JwtServices;
using FullFraim.Web.Configurations.StartupConfig;
using FullFraim.Web.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
<<<<<<< HEAD
using Utilities.CloudinaryUtils;
=======
using Utilities.Mailing;
>>>>>>> 2094a27bbe0569d1f5082b530efea7d28bf2f1f6

namespace FullFraim.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FullFraimDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllersWithViews();
            services.AddControllers();

            AuthenticationConfig.SingInConfiguration(services);

            services.AddScoped<IJwtServices, JwtServices>();
<<<<<<< HEAD
            services.AddTransient<ICloudinaryService, CloudinaryService>();
=======
            services.AddTransient<IEmailSender>(
                serviceProvider => new SendGridEmailSender(Configuration["SendGrid:ApiKey"]));
            services.AddTransient<APIExceptionFilter>();
>>>>>>> 2094a27bbe0569d1f5082b530efea7d28bf2f1f6

            AuthenticationConfig.ConfigureWith_Jwt(services, Configuration);

            SwaggerConfig.Configure(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FullFraim");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
