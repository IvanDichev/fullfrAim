using Microsoft.AspNetCore.Mvc;

namespace FullFraim.Web.Controllers
{
    public class DashboardController : Controller
    {
        public DashboardController()
        {

        }
        public IActionResult Index()
        {
            //var model = new ContestViewModel();
            //model.TestProperty = 1;
            //model.TestListProperty = new List<string>(){"uno", "dos", "tres" };

            //  return View(model); 
            return View();
        }

        public IActionResult TestPartialInController()
        {
            return PartialView("~/Views/Shared/Partials/_TestPartial.cshtml", 5);
        }
    }
}
