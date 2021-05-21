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
    public class DashboardController : Controller
    {
        private readonly IContestService contestService;
        private readonly IContestCategoryService contestCategory;

        public DashboardController(IContestService contestService, IContestCategoryService contestCategory)
        {
            this.contestService = contestService;
            this.contestCategory = contestCategory;
        }
        public IActionResult Index() // TODO: Shall we make it async?
        {
            var dashboardViewModel = new DashboardViewModel()
            {
                Contests = GetContestsByCategory(0).Result // Just for test - Bad practice
            };

            return View(dashboardViewModel);
        }

        public async Task<IEnumerable<ContestViewModel>> GetContestsByCategory(int categoryId) // Move to service layer
        {
            var categories = (await this.contestService.GetAllAsync());

            if (categoryId != 0)
            {
                categories.Where(c => c.Id == categoryId);
               
            }

            var result = categories.Select(x => x.MapToView());

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
