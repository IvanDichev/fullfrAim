using FullFraim.Models.Dto_s.Pagination;
using FullFraim.Models.ViewModels.Enrolling;
using FullFraim.Services.ContestCatgeoryServices;
using FullFraim.Services.ContestServices;
using FullFraim.Services.PhotoJunkieServices;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Utilities.CloudinaryUtils;
using Utilities.Mapper;

namespace FullFraim.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IContestService contestService;
        private readonly IContestCategoryService contestCategoryService;
        private readonly IPhotoJunkieService photoJunkieService;
        private readonly ICloudinaryService cloudinaryService;

        public DashboardController(IContestService contestService, 
            IContestCategoryService contestCategoryService,
            IPhotoJunkieService photoJunkieService,
            ICloudinaryService cloudinaryService)
        {
            this.contestService = contestService;
            this.contestCategoryService = contestCategoryService;
            this.photoJunkieService = photoJunkieService;
            this.cloudinaryService = cloudinaryService;
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

        [HttpGet]
        public IActionResult Enroll(int contestId)
        {
            return PartialView("~/Views/Shared/Partials/_EnrollPartial.cshtml", 
                new EnrollViewModel() { ContestId = contestId});
        }

        [HttpPost]
        public async Task<IActionResult> Enroll(EnrollViewModel model)
        {
            model.UserId = int.Parse
                (HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if(!ModelState.IsValid)
            {
                return PartialView("~/Views/Shared/Partials/_EnrollPartial.cshtml", model);
            }

            string imageUrl = this.cloudinaryService
                .UploadImage(model.Photo);

            await photoJunkieService
                .EnrollForContestAsync(model.MapToDto(imageUrl));

            return RedirectToAction
                (nameof(Index), nameof(DashboardController)
                .Replace("Controller", string.Empty));
        }

        public IActionResult TestPartialInController()
        {
            return PartialView("~/Views/Shared/Partials/_TestPartial.cshtml", 5);
        }
    }
}
