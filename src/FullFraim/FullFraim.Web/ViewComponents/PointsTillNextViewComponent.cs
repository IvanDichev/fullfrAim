using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Pagination;
using FullFraim.Models.Dto_s.PhotoJunkies;
using FullFraim.Models.ViewModels.Dashboard;
using FullFraim.Services.PhotoJunkieServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public PointsTillNextViewComponent
            (IPhotoJunkieService photoJunkieService,
            UserManager<User> userManager)
        {
            this.photoJunkieService = photoJunkieService;
            this.userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(PaginationFilter pagination)
        {
            if(int.Parse(HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier).Value) != 1)
            {
                return Content(string.Empty);
            }

            if(pagination == null)
            {
                pagination = new PaginationFilter();
            }

            var junkies = await userManager.Users
                .Skip(pagination.PageSize * (pagination.PageNumber - 1))
                .Take(pagination.PageSize)
                .Where(x => x.Id != 1)
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

            TempData["pagination"] = pagination;

            return View(result);
        }
    }
}
