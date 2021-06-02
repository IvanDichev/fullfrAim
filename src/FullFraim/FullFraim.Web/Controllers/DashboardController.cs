using FullFraim.Models.Dto_s.Pagination;
using FullFraim.Models.ViewModels.Enrolling;
using FullFraim.Models.ViewModels.Contest;
using FullFraim.Services.ContestCatgeoryServices;
using FullFraim.Services.ContestServices;
using FullFraim.Services.PhotoJunkieServices;
using FullFraim.Services.PhotoService;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Utilities.CloudinaryUtils;
using Utilities.Mapper;
using FullFraim.Services.JuryServices;
using FullFraim.Models.Dto_s.Photos;

namespace FullFraim.Web.Controllers
{
    public class DashboardController : BaseMvcController
    {
        private readonly IContestService contestService;
        private readonly IContestCategoryService contestCategoryService;
        private readonly IPhotoJunkieService photoJunkieService;
        private readonly IJuryService juryService;
        private readonly IPhotoService photoService;
        private readonly ICloudinaryService cloudinaryService;

        public DashboardController(IContestService contestService, 
            IContestCategoryService contestCategoryService,
            IPhotoJunkieService photoJunkieService,
            IJuryService juryService,
            IPhotoService photoService,
            ICloudinaryService cloudinaryService)
        {
            this.contestService = contestService;
            this.contestCategoryService = contestCategoryService;
            this.photoJunkieService = photoJunkieService;
            this.juryService = juryService;
            this.photoService = photoService;
            this.cloudinaryService = cloudinaryService;
        }

        public async Task<IActionResult> Index(int categoryId)
        {
            int userId = UserId;

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
            model.UserId = UserId;

            var canEnroll = await photoJunkieService
                .CanJunkyEnroll(model.ContestId, model.UserId);

            if(canEnroll == false)
            {
                ModelState
                    .AddModelError(string.Empty,
                    errorMessage: "You cannot enroll in this contest");
            }

            if(!ModelState.IsValid)
            {
                return PartialView("~/Views/Shared/Partials/_EnrollPartial.cshtml", model);
            }

            string imageUrl = this.cloudinaryService
                .UploadImage(model.Photo);

            await photoJunkieService
                .EnrollForContestAsync(model.MapToDto(imageUrl));

            return Json(new { isValid = true });
        }

        public IActionResult TestPartialInController()
        {
            return PartialView("~/Views/Shared/Partials/_TestPartial.cshtml", 5);
        }

        public async Task<IActionResult> GetById(int id)
        {
            int userId = UserId;

            var contestSubmissions = await this.photoService
                .GetDetailedSubmissionsFromContestAsync(id, new PaginationFilter());

            var paginatedModel = new PaginatedModel<ContestSubmissionViewModel>()
            {
                Model = contestSubmissions.Model.Select(m => m.MapToContestSubmissionView())
                     .ToList(),
                RecordsPerPage = contestSubmissions.RecordsPerPage,
                TotalPages = contestSubmissions.TotalPages,
            };

          //  paginatedModel.Model.FirstOrDefault(m => m.AuthorId == UserId).IsCurrentUserSubmission = true; // TODO: Make validation if null!!!

            return View(paginatedModel);
        }

        public async Task<IActionResult> GetByIdUserSubmission(int id)
        {
            int userId = UserId;

            var submission = await this.photoService
                .GetUserSubmissionForContestAsync(userId, id);

            return View(submission);
        }

        [HttpGet]
        public async Task<IActionResult> GiveReview(int contestId, int submitterId)
        {
            int userId = UserId;

            var submission = await this.photoService.GetUserSubmissionForContestAsync(submitterId, contestId);

            var giveReviewViewModel = new GiveReviewViewModel()
            { 
                PhotoUrl = submission.Url,
                Author = submission.SubmitterName,
                Description = submission.Description,
                Title = submission.Title,
            };
            // can user open this page
            // if not unauthorized

            // Getsubmission

            //return view with model
            return View("~/Views/Dashboard/GiveReview.cshtml",
                giveReviewViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> GiveReview(GiveReviewViewModel model)
        {
            // Can jury make review for given photo?
            // Invalid? Unauthorized/

            //give review
            var review = await this.juryService.GiveReviewAsync(model.MapToInputGiveReviewDto());

            return View(review);
            //redirectTo()
        }
    }
}
