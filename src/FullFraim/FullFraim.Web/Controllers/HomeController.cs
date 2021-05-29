using FullFraim.Models.Dto_s.Photos;
using FullFraim.Services.PhotoService;
using FullFraim.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FullFraim.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IPhotoService photoService;
        private readonly IMemoryCache cache;

        public HomeController(ILogger<HomeController> logger, 
            IPhotoService photoService,
            IMemoryCache cache)
        {
            this.logger = logger;
            this.photoService = photoService;
            this.cache = cache;
        }

        public async Task<IActionResult> Index()
        {
            if(!cache.TryGetValue<ICollection<PhotoDto>>("photos", out var photos))
            {
                photos = await this.photoService.GetTopRecentPhotosAsync();
                cache.Set("photos", photos, TimeSpan.FromDays(1));
            }

            return View(photos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
