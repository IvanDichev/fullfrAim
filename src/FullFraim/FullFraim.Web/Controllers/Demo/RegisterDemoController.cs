using FullFraim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Utilities.Mailing;

namespace FullFraim.Web.Controllers.Demo
{
    public class RegisterDemoController : Controller
    {
        private readonly IEmailSender emailSender;
        private readonly IConfiguration configuration;

        public RegisterDemoController(IEmailSender emailSender, IConfiguration configuration)
        {
            this.emailSender = emailSender;
            this.configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendgridEmailSubmit(EmailModel emailModel)
        {
            ViewData["Message"] = "Email Sent!!!...";
            var emailDemo = new SendGridEmailSender(configuration["SendGrid:ApiKey"]);
            await emailDemo.SendEmailAsync(emailModel.From, emailModel.To, emailModel.Subject, emailModel.Body
                , emailModel.Body);

            return View(emailDemo);
        }
    }
}
