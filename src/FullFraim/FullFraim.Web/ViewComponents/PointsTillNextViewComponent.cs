using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.PhotoJunkies;
using FullFraim.Models.ViewModels.Dashboard;
using FullFraim.Services.PhotoJunkieServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities.Mapper;

namespace FullFraim.Web.ViewComponents
{
    public class PointsTillNextViewComponent : ViewComponent
    {
        private readonly IPhotoJunkieService photoJunkieService;
        private readonly UserManager<User> userManager;

        public PointsTillNextViewComponent
            (IPhotoJunkieService photoJunkieService,
            UserManager<User> userManager)
        {
            this.photoJunkieService = photoJunkieService;
            this.userManager = userManager;
        }

        public async Task<IViewComponentResult> Invoke()
        {
            var junkies = await userManager.Users.ToListAsync();

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
