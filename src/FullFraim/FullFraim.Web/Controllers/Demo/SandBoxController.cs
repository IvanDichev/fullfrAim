using FullFraim.Models.Dto_s.Juries;
using FullFraim.Models.Dto_s.PhotoJunkies;
using FullFraim.Services.JuryServices;
using FullFraim.Services.PhotoJunkieServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FullFraim.Web.Controllers.Demo
{
    public class SandBoxController : Controller
    {
        private readonly IPhotoJunkieService photoJunkieService;
        private readonly IJuryService juryService;

        public SandBoxController(IPhotoJunkieService photoJunkieService, IJuryService juryService)
        {
            this.photoJunkieService = photoJunkieService;
            this.juryService = juryService;
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
                PhotoUrl = "url",
            };

            await this.photoJunkieService.EnrollForContestAsync(input);

            return View();
        }

        public async Task<IActionResult> JuryContests()
        {
            var contests = await this.juryService.GetContestsAsync(1);

            return View(contests);
        }

        public async Task<IActionResult> ReviewPhoto()
        {
            var input = new InputGiveReviewDto()
            {
                Comment = "The best and the only photo we have",
                Score = 10,
                Checkbox = false,
                PhotoId = 1,
                JuryId = 1
            };

            await this.juryService.GiveReviewAsync(input);

            return View();
        }
    }
}
