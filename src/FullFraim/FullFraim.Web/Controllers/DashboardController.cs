using FullFraim.Models.Dto_s.Contests;
using FullFraim.Models.ViewModels;
using FullFraim.Services.ContestCatgeoryServices;
using FullFraim.Services.ContestServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Utilities.Mapper;
using FullFraim.Models.ViewModels.Dashboard;
using System.Security.Claims;
using FullFraim.Models.Dto_s.Pagination;
using FullFraim.Services.Exceptions;

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
        public async Task<IActionResult> Index(int categoryId) // TODO: Shall we make it async?
        {
            var dashboardViewModel = new DashboardViewModel()
            {
                Contests = await GetContestsByCategory(categoryId),
                Categories = await this.contestCategoryService.GetAllAsync()
            };

            return View(dashboardViewModel);
        }

        public async Task<IEnumerable<DashboardViewModel>> GetContestsByCategory(int categoryId) // Move to service layer
        {
            if(categoryId < 0)
            {
                throw new InvalidIdException();
            }

            int userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var paginatedModel = await this.contestService.GetAllAsync(userId, new PaginationFilter());

            if (categoryId != 0)
            {
                var categories = paginatedModel.Model.Where(c => c.ContestCategoryId == categoryId).ToList();
                var result = categories.Select(x => x.MapToViewDashboard());

                return result;
            }


            return paginatedModel.Model.Select(x => x.MapToViewDashboard());
        }

        



        //public async Task<IActionResult> ListContestsAsync(string category)
        //{
        //    string selectedCategory = category;
        //    ICollection<ContestViewModel> contestViewModels;

        //    string currentCategory = string.Empty;

        //    if (string.IsNullOrEmpty(category))
        //    {
        //        contestViewModels = await this.contestService.GetAllAsync()
        //    }
        //}

        public IActionResult TestPartialInController()
        {
            return PartialView("~/Views/Shared/Partials/_TestPartial.cshtml", 5);
        }
    }
}
