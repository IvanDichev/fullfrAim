using FullFraim.Models.Dto_s.Pagination;
using FullFraim.Models.ViewModels.Contest;
using FullFraim.Services.ContestCatgeoryServices;
using FullFraim.Services.ContestServices;
using FullFraim.Services.PhotoService;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Utilities.Mapper;

namespace FullFraim.Web.Controllers
{
    public class DashboardController : BaseMvcController
    {
        private readonly IContestService contestService;
        private readonly IContestCategoryService contestCategoryService;
        private readonly IPhotoService photoService;

        public DashboardController
            (IContestService contestService, IContestCategoryService contestCategoryService, IPhotoService photoService)
        {
            this.contestService = contestService;
            this.contestCategoryService = contestCategoryService;
            this.photoService = photoService;
        }

        public async Task<IActionResult> Index(int categoryId)
        {
            int userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var dashboardViewModel =
                (await this.contestService.GetAllForUserAsync(userId, new PaginationFilter())).Model
                    .Select(x => x.MapToViewDashboard()).ToList();

            ViewBag.Categories = await this.contestCategoryService.GetAllAsync();

            return View(dashboardViewModel);
        }

        public IActionResult TestPartialInController()
        {
            return PartialView("~/Views/Shared/Partials/_TestPartial.cshtml", 5);
        }

        public async Task<IActionResult> GetById(int id)
        {
            int userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var contestSubmissions = await this.photoService
                .GetDetailedSubmissionsFromContestAsync(id, new PaginationFilter());

            var paginatedModel = new PaginatedModel<ContestSubmissionViewModel>()
            {
                Model = contestSubmissions.Model.Select(m => m.MapToContestSubmissionView())
                     .ToList(),
                RecordsPerPage = contestSubmissions.RecordsPerPage,
                TotalPages = contestSubmissions.TotalPages,
            };

            paginatedModel.Model.FirstOrDefault(m => m.AuthorId == UserId).IsCurrentUserSubmission = true; // TODO: Make validation if null!!!

            return View(paginatedModel);
        }
    }
}
