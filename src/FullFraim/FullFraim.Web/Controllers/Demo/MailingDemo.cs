using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Utilities.Mailing;

namespace FullFraim.Web.Controllers.Demo
{
    public class MailingDemo : Controller
    {
        private readonly IEmailSender emailSender;

        public MailingDemo(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }
        public async Task<IActionResult> Index()
        {
            await this.emailSender.SendEmailAsync("fullfraim@gmail.com", "fullFraim", "boryana.gm@gmail.com", "test", "test");
            return View();
        }
    }
}
