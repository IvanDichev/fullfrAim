using FullFraim.Models.ViewModels.Dashboard;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FullFraim.Web.Controllers
{
    public class DashboardController : Controller
    {
        public DashboardController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TestPartialInController()
        {
            return PartialView("~/Views/Shared/Partials/_TestPartial.cshtml", 5);
        }
    }
}
