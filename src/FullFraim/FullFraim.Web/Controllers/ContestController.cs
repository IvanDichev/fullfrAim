using FullFraim.Models.Contest.ViewModels;
using FullFraim.Models.Dto_s.User;
using FullFraim.Services.ContestCatgeoryServices;
using FullFraim.Services.ContestServices;
using FullFraim.Services.ContestTypeServices;
using FullFraim.Services.PhaseServices;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<IActionResult> Create(string url)
        {
            ViewBag.Categories = await this.contestCategoryService
                    .GetAllAsync();

            ViewBag.ContestTypes = await this.contestTypeService
                .GetAllAsync();

            ViewBag.Cover = url;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContestViewModel model)
        {
            if (!ModelState.IsValid || 
                (model.Cover_Url != null && model.Cover != null) ||
                (model.Cover_Url == null && model.Cover == null))
            {
                ViewBag.Categories = await this.contestCategoryService
                    .GetAllAsync();

                ViewBag.ContestTypes = await this.contestTypeService
                    .GetAllAsync();

                return View(model);
            }

            if (model.Cover != null && model.Cover_Url == null)
            {

                model.Cover_Url = this.cloudinaryService.UploadImage(model.Cover);

                await this.contestService.CreateAsync(model.MapToDto());

                return RedirectToAction(nameof(HomeController.Index), 
                    nameof(HomeController).Replace("Controller", string.Empty));
            }
            else if(model.Cover == null && model.Cover_Url != null)
            {
                await this.contestService.CreateAsync(model.MapToDto());

                return RedirectToAction(nameof(HomeController.Index),
                    nameof(HomeController).Replace("Controller", string.Empty));
            }

            throw new Exception();
        }

        public async Task<IActionResult> ChooseCovers()
        {
            var result = await this.contestService.GetCoversAsync();

            ViewBag.Covers = result;

            return View();
        }
    }
}
