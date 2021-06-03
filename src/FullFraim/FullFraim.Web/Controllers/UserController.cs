using FullFraim.Data.Models;
using FullFraim.Models.Dto_s.Pagination;
using FullFraim.Models.ViewModels.Dashboard;
using FullFraim.Models.ViewModels.Sorting;
using FullFraim.Services.PhotoJunkieServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities.Mapper;
using static Shared.Constants;
using FullFraim.Models.ViewModels.User;

namespace FullFraim.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly IPhotoJunkieService photoJunkieService;
        private readonly UserManager<User> userManager;
        private static readonly List<SortingViewModel> sortingCollection = new List<SortingViewModel>()
        {
            new SortingViewModel()
            {
                ViewName = Sorting.FirstNameAscView,
                ServerName = Sorting.FirstNameAsc
            },
            new SortingViewModel()
            {
                ViewName = Sorting.FirstNameDescView,
                ServerName = Sorting.FirstNameDesc
            },
            new SortingViewModel()
            {
                ViewName = Sorting.LastNameAscView,
                ServerName = Sorting.LastNameAsc
            },
            new SortingViewModel()
            {
                ViewName = Sorting.LastNameDescView,
                ServerName = Sorting.LastNameDesc
            },
            new SortingViewModel()
            {
                ViewName = Sorting.RankAscView,
                ServerName = Sorting.RankAsc
            },
            new SortingViewModel()
            {
                ViewName = Sorting.RankDescView,
                ServerName = Sorting.RankDesc
            },
            new SortingViewModel()
            {
                ViewName = Sorting.PointsAscView,
                ServerName = Sorting.PointsAsc
            },
            new SortingViewModel()
            {
                ViewName = Sorting.PointsDescView,
                ServerName = Sorting.PointsDesc
            }
        };

        public UserController(IConfiguration configuration,
            IPhotoJunkieService photoJunkieService,
            UserManager<User> userManager)
        {
            this.configuration = configuration;
            this.photoJunkieService = photoJunkieService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index(string orderBy = "" , int pageNumber = 1)
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

            ViewBag.Sorting = sortingCollection;

            var ViewResult = new UsersPageViewModel()
            {
                sorting = orderBy,
                Model = result,
            };

            return View(ViewResult);
        }
    }
}
