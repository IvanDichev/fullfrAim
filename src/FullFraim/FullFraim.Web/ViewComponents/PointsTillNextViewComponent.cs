using FullFraim.Data.Models;
using FullFraim.Models.ViewModels.Dashboard;
using FullFraim.Services.PhotoJunkieServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Utilities.Mapper;

namespace FullFraim.Web.ViewComponents
{
    public class PointsTillNextViewComponent : ViewComponent
    {
        private readonly IPhotoJunkieService photoJunkieService;
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;

        public PointsTillNextViewComponent
            (IPhotoJunkieService photoJunkieService,
            UserManager<User> userManager, IConfiguration configuration)
        {
            this.photoJunkieService = photoJunkieService;
            this.userManager = userManager;
            this.configuration = configuration;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if(int.Parse(HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier).Value) != 1)
            {
                return Content(string.Empty);
            }

            var junkies = await userManager.Users
                .Where(x => x.FirstName != configuration["AccountAdminInfo:UserName"])
                .Take(5)
                .ToListAsync();

            var result = new List<PointsTillNextViewModel>();

            foreach (var junkie in junkies)
            {
                var photojunkieWithPoints = await photoJunkieService
                    .GetPointsTillNextRankAsync(junkie.Id);

                result
                    .Add(photojunkieWithPoints
                    .MapToPointsViewModel
                    (junkie.FirstName + junkie.LastName));
            }

            return View(result);
        }
    }
}
