using FullFraim.Models.ViewModels;
using FullFraim.Services.ContestServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullFraim.Web.Controllers
{
    public class ContestController : Controller
    {
        private readonly ContestService contestService;

        public ContestController(ContestService contestService)
        {
            this.contestService = contestService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContestViewModel model)
        {
            throw new Exception();
        }
    }
}
