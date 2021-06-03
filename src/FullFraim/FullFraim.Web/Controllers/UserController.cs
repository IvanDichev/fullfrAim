using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Pagination;
using FullFraim.Models.ViewModels.Dashboard;
using FullFraim.Services.PhotoJunkieServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Mapper;

namespace FullFraim.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly IPhotoJunkieService photoJunkieService;
        private readonly UserManager<User> userManager;

        public UserController(IConfiguration configuration,
            IPhotoJunkieService photoJunkieService,
            UserManager<User> userManager)
        {
            this.configuration = configuration;
            this.photoJunkieService = photoJunkieService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index(string orderBy = "asc" , int pageNumber = 1)
        {
            var junkies = await this.photoJunkieService
                .GetAllAsync(new SortingModel() { OrderBy = orderBy },
                new PaginationFilter() { PageNumber = pageNumber });

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
