using FullFraim.Models.Contest.ViewModels;
using FullFraim.Models.Dto_s.Pagination;
using FullFraim.Models.ViewModels.Dashboard;
using FullFraim.Services.ContestCatgeoryServices;
using FullFraim.Services.ContestServices;
using FullFraim.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Utilities.Mapper;

namespace FullFraim.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IContestService contestService;
        private readonly IContestCategoryService contestCategoryService;

        public DashboardController(IContestService contestService, IContestCategoryService contestCategoryService)
        {
            this.contestService = contestService;
            this.contestCategoryService = contestCategoryService;
        }

        public async Task<IActionResult> Index(int categoryId)
        {
            int userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var dashboardViewModel = 
                (await this.contestService.GetAllForUserAsync(userId, new PaginationFilter(), categoryId)).Model
                    .Select(x => x.MapToViewDashboard()).ToList();

            ViewBag.Categories = await this.contestCategoryService.GetAllAsync();

            return View(dashboardViewModel);
        }

        public IActionResult TestPartialInController()
        {
            return PartialView("~/Views/Shared/Partials/_TestPartial.cshtml", 5);
        }
    }
}
