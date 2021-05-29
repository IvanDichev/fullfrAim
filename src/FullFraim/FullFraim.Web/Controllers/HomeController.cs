using FullFraim.Services.PhotoService;
using FullFraim.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

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
            var photos = await this.photoService.GetTopRecentPhotosAsync();
            var images = new List<string>();
            images.Add("11");

            return View(photos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
