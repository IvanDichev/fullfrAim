using FullFraim.Models.Dto_s.PhotoJunkies;
using FullFraim.Services.PhotoJunkieServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FullFraim.Web.Controllers.Demo
{
    public class SandBoxController : Controller
    {
        private readonly IPhotoJunkieService photoJunkieService;

        public SandBoxController(IPhotoJunkieService photoJunkieService)
        {
            this.photoJunkieService = photoJunkieService;
        }

        public async Task<IActionResult> JunkieContests()
        {
            var contests = await this.photoJunkieService.GetContestsAsync(8);

            return View(contests);
        } 
        
        public async Task<IActionResult> EnrollJunkie()
        {
            var input = new InputEnrollForContestDto()
            {
                UserId = 8,
                ContestId = 1,
                ImageDescription = "neshto",
                ImageTitle = "title",
                ImageUrl = "url",
            };

            await this.photoJunkieService.EnrollForContestAsync(input);

            return View();
        }
    }
}
