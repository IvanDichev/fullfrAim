using FullFraim.Models.Contest.ViewModels;
using FullFraim.Models.Dto_s.Pagination;
using FullFraim.Services.ContestCatgeoryServices;
using FullFraim.Services.ContestServices;
using FullFraim.Services.ContestTypeServices;
using FullFraim.Services.PhaseServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Utilities.CloudinaryUtils;
using Utilities.Mapper;

namespace FullFraim.Web.Controllers
{
    [Controller]
    public class ContestController : Controller
    {
        private readonly IContestService contestService;
        private readonly IContestCategoryService contestCategoryService;
        private readonly IPhaseService phaseService;
        private readonly IContestTypeService contestTypeService;
        private readonly ICloudinaryService cloudinaryService;

        public ContestController(IContestService contestService,
            IContestCategoryService contestCategoryService,
            IPhaseService phaseService,
            IContestTypeService contestTypeService,
            ICloudinaryService cloudinaryService)
        {
            this.contestService = contestService;
            this.contestCategoryService = contestCategoryService;
            this.phaseService = phaseService;
            this.contestTypeService = contestTypeService;
            this.cloudinaryService = cloudinaryService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await SeedDropdownsForContest();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContestViewModel model)
        {
            if (!await this.contestService.IsNameUniqueAsync(model.Name))
            {
                ModelState.AddModelError(string.Empty, "Name must be unique!");
            }

            if (model.Cover_Url != null && model.Cover != null)
            {
                ModelState
                    .AddModelError(string.Empty, "Cannot send both url and image file!");
            }

            if (model.Cover == null && model.Cover_Url == null)
            {
                ModelState
                    .AddModelError(string.Empty, "Contest cover is *Required");
            }

            if (!ModelState.IsValid)
            {
                await SeedDropdownsForContest();

                return View(model);
            }

            if (model.Cover != null && model.Cover_Url == null)
            {
                model.Cover_Url = this.cloudinaryService.UploadImage(model.Cover);
            }

            if(model.ContestTypeId == 2 
                && model.Jury == null 
                && model.Participants == null)
            {
                throw new System.Exception();
            }

            var contest = await this.contestService.CreateAsync(model.MapToDto());

            return RedirectToAction(nameof(HomeController.Index),
                nameof(HomeController).Replace("Controller", string.Empty));
        }

        [HttpGet]
        public async Task<IActionResult> ChooseCovers()
        {
            var result = await this.contestService.GetConetstCoversAsync(new PaginationFilter());

            ViewBag.Covers = result;

            return View();
        }

        [NonAction]
        private async Task SeedDropdownsForContest()
        {
            ViewBag.Categories = await this.contestCategoryService
                    .GetAllAsync();

            ViewBag.Phases = await this.phaseService
                .GetAllAsync();

            ViewBag.ContestTypes = await this.contestTypeService
                .GetAllAsync();

            ViewBag.Jury = await this.contestService.GetPotentialJuryForInvitationAsync();
            ViewBag.Participants = await this.contestService.GetParticipantsForInvitationAsync();
        }
    }
}
