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

namespace FullFraim.Web.Controllers
{
    [Controller]
    public class DashboardController : Controller
    {
        private readonly IContestService contestService;
        private readonly IContestCategoryService contestCategoryService;

        public DashboardController(IContestService contestService, IContestCategoryService contestCategoryService)
        {
            this.contestService = contestService;
            this.contestCategoryService = contestCategoryService;
        }
        public IActionResult Index(int categoryId) // TODO: Shall we make it async?
        {
            var dashboardViewModel = new DashboardViewModel()
            {
                Contests = GetContestsByCategory(categoryId).GetAwaiter().GetResult(), 
                Categories = this.contestCategoryService.GetAllAsync().GetAwaiter().GetResult()
            };

            return View(dashboardViewModel);
        }

        public async Task<IEnumerable<DashboardViewModel>> GetContestsByCategory(int categoryId) // Move to service layer
        {
            var categories = await this.contestService.GetAllAsync();

            if (categoryId != 0)
            {
                categories = categories.Where(c => c.ContestCategoryId == categoryId).ToList();
            }

            var result = categories.Select(x => x.MapToViewDashboard());

            return result;
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
