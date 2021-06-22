using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Framework.Application;
using Framework.Application.Authentication;
using GoogleReCaptcha.V3.Interface;
using MarketPlace.ApplicationContract.AI.Site;
using MarketPlace.ApplicationContract.ViewModels.Site;
using MarketPlace.Query.Contract.Site.SiteBanner;

namespace ServiceHost.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ISiteBannerQuery _siteBannerQuery;
        private readonly ICaptchaValidator _captchaValidator;
        private readonly IContactUsApplication _contactUsApplication;

        public HomeController(ISiteBannerQuery siteBannerQuery, ICaptchaValidator captchaValidator, IContactUsApplication contactUsApplication)
        {
            _siteBannerQuery = siteBannerQuery;
            _captchaValidator = captchaValidator;
            _contactUsApplication = contactUsApplication;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Banners = await _siteBannerQuery.GetBannersBy(new List<BannerPosition>
                {BannerPosition.FirstRow, BannerPosition.SecondRow, BannerPosition.ThirdRow});

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