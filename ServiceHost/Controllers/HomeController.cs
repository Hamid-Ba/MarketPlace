using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Framework.Application.Authentication;
using GoogleReCaptcha.V3.Interface;
using MarketPlace.ApplicationContract.AI.Site;
using MarketPlace.ApplicationContract.ViewModels.Site;

namespace ServiceHost.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ICaptchaValidator _captchaValidator;
        private readonly IContactUsApplication _contactUsApplication;

        public HomeController(ICaptchaValidator captchaValidator, IContactUsApplication contactUsApplication)
        {
            _captchaValidator = captchaValidator;
            _contactUsApplication = contactUsApplication;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Contact-Us")]
        public IActionResult ContactUs() => View();

        [HttpPost("Contact-Us"), ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactUs(CreateContactUsVM command)
        {
            if (!await _captchaValidator.IsCaptchaPassedAsync(command.Captcha))
            {
                TempData[ErrorMessage] = "کد کپچای شما تایید نشد";
                return View(command);
            }

            if (ModelState.IsValid)
            {
                var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
                var userId = User.GetUserId();

                var result = await _contactUsApplication.SendMessage(command, ip.ToString(), userId);

                TempData[SuccessMessage] = result.Message;
            }

            return View(command);
        }
    }
}