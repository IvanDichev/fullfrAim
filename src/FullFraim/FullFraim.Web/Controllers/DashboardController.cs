using FullFraim.Models.Dto_s.Pagination;
using FullFraim.Models.Dto_s.Reviews;
using FullFraim.Models.ViewModels.Contest;
using FullFraim.Models.ViewModels.Enrolling;
using FullFraim.Services.ContestCatgeoryServices;
using FullFraim.Services.ContestServices;
using FullFraim.Services.JuryServices;
using FullFraim.Services.PhotoJunkieServices;
using FullFraim.Services.PhotoService;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.AllConstants;
using System.Linq;
using System.Threading.Tasks;
using Utilities.CloudinaryUtils;
using Utilities.Mapper;

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

            foreach (var viewModel in dashboardViewModel)
            {
                viewModel.HasCurrentUserSybmittedPhoto = await this.photoJunkieService.HasCurrentUserSubmittedPhoto(userId, viewModel.ContestId);
            }

            ViewBag.Categories = await this.contestCategoryService.GetAllAsync();

            return View(dashboardViewModel);
        }

        [HttpGet]
        public IActionResult Enroll(int contestId)
        {
            return PartialView("~/Views/Shared/Partials/_EnrollPartial.cshtml",
                new EnrollViewModel() { ContestId = contestId });
        }

        [HttpPost]
        public async Task<IActionResult> Enroll(EnrollViewModel model)
        {
            model.UserId = UserId;

            //var canEnroll = await photoJunkieService
            //    .CanJunkyEnroll(model.ContestId, model.UserId);

            //if (canEnroll == false)
            //{
            //    ModelState
            //        .AddModelError(string.Empty,
            //        errorMessage: ErrorMessages.CannotEnroll);
            //}

            if (!ModelState.IsValid)
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
            // check if user is jury and if phase is phase two
            if(!((await this.contestService.GetByIdAsync(contestId)).ActivePhase.Name == Constants.Phases.PhaseII &&
                await this.juryService.IsUserJuryForContest(contestId, UserId))) // is jury in contest - true
            {
                return Unauthorized();
            }

            var submission = await this.photoService.GetUserSubmissionForContestAsync(submitterId, contestId);

            var giveReviewViewModel = new GiveReviewViewModel
            {
                PhotoUrl = submission.Url,
                Author = submission.SubmitterName,
                Description = submission.Description,
                Title = submission.Title,
                HasJuryGivenReview = await this.juryService.IsJuryGivenReviewForPhotoAsync(submission.Id, this.UserId)
            };

            // TODO: Check if Jury has already given review - use HasJuryGivenReview property?

            if (giveReviewViewModel.HasJuryGivenReview)
            {
                var review = await this.juryService.GetReviewAsync(UserId, submission.Id);
                giveReviewViewModel.Review = new InputGiveReviewDto()
                {
                    Score = review.Score,
                    Comment = review.Comment,
                    Checkbox = review.IsDisqualified,
                };

                // get data from service for review
            }
            else
            {
                // if review has not been given yet
               // giveReviewViewModel.HasJuryGivenReview = await this.photoService.IsJuryGivenReviewForPhotoAsync(submission.Id, this.UserId);
                giveReviewViewModel.Review = new InputGiveReviewDto()
                {
                    JuryId = this.UserId,
                    PhotoId = submission.Id,
                };

            }
            return View("~/Views/Dashboard/GiveReview.cshtml",
                giveReviewViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> GiveReview(GiveReviewViewModel model)
        {
            model.JuryId = UserId;

            if (!await juryService.IsContestInPhaseTwoAsync(model.PhotoId))
            {
                ModelState
                   .AddModelError(string.Empty,
                   errorMessage: ErrorMessages.ReviewOutsidePhaseTwo);
            }

            if (await juryService.HasJuryAlreadyGivenReviewAsync(model.JuryId, model.PhotoId))
            {
                ModelState
                   .AddModelError(string.Empty,
                   errorMessage: ErrorMessages.ReviewAlreadyGiven);
            }

            // TODO: How to check if user is a Jury or a invated Photo Master?

            var review = await this.juryService.GiveReviewAsync(model.MapToInputGiveReviewDto());
            model.HasJuryGivenReview = true;

            return RedirectToAction(nameof(GetById), new { id = review.ContestId });
            //redirectTo()
        }
    }
}
