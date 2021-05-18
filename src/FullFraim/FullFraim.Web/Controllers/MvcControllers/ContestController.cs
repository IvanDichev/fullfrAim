using FullFraim.Models.ViewModels;
using FullFraim.Services.ContestCatgeoryServices;
using FullFraim.Services.ContestServices;
using FullFraim.Services.ContestTypeServices;
using FullFraim.Services.PhaseServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullFraim.Web.Controllers.MvcControllers
{
    [Controller]
    public class ContestController : Controller
    {
        private readonly IContestService contestService;
        private readonly IContestCategoryService contestCategoryService;
        private readonly IPhaseService phaseService;
        private readonly IContestTypeService contestTypeService;

        public ContestController(IContestService contestService,
            IContestCategoryService contestCategoryService,
            IPhaseService phaseService,
            IContestTypeService contestTypeService)
        {
            this.contestService = contestService;
            this.contestCategoryService = contestCategoryService;
            this.phaseService = phaseService;
            this.contestTypeService = contestTypeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await this.contestCategoryService
                    .GetAllAsync();

            ViewBag.Phases = await this.phaseService
                .GetAllAsync();

            ViewBag.ContestTypes = await this.contestTypeService
                .GetAllAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContestViewModel model)
        {
            if(ModelState.IsValid)
            {


            }
                return Ok();
        }
    }
}
