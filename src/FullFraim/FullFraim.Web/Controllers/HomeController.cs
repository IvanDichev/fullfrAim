using FullFraim.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using FullFraim.Services.PhotoService;
using System.Threading.Tasks;
using System.Linq;
using FullFraim.Models.ViewModels.Home;
using System.Collections.Generic;

namespace FullFraim.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IPhotoService photoService;

        public HomeController(ILogger<HomeController> logger, IPhotoService photoService)
        {
            this.logger = logger;
            this.photoService = photoService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
