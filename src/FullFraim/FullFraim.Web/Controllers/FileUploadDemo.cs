using FullFraim.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Utilities.CloudinaryUtils;

namespace FullFraim.Web.Controllers
{
    public class FileUploadDemo : Controller
    {
        private readonly ICloudinaryService cloudinaryService;

        public FileUploadDemo(ICloudinaryService cloudinaryService)
        {
            this.cloudinaryService = cloudinaryService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Index(ImageInputUploadDemo input)
        {
            var imageUrl = this.cloudinaryService.UploadImage(input.Image);

            var resp = new ImageInputUploadDemo() 
            {
                ImageUrl = imageUrl,
            };

            return View(resp);
        }
    }
}
