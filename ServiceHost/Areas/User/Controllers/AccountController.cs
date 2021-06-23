using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Framework.Application.Authentication;
using GoogleReCaptcha.V3.Interface;
using MarketPlace.ApplicationContract.AI.Account;
using MarketPlace.ApplicationContract.ViewModels.Account;

namespace ServiceHost.Areas.User.Controllers
{
    public class AccountController : UserBaseController
    {
        private readonly IUserApplication _userApplication;
        private readonly ICaptchaValidator _captchaValidator;

        public AccountController(IUserApplication userApplication, ICaptchaValidator captchaValidator)
        {
            _userApplication = userApplication;
            _captchaValidator = captchaValidator;
        }

        [HttpGet("Change-Pass")]
        public IActionResult ChangePassword() => View();

        [HttpPost("Change-Pass"), ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordUserVM command)
        {
            if (!await _captchaValidator.IsCaptchaPassedAsync(command.Captcha))
            {
                TempData[ErrorMessage] = "کپچای شما تایید نشد";
                return View(command);
            }

            if (ModelState.IsValid)
            {
                var result = await _userApplication.ChangePassword(User.GetUserId(), command);

                if (result.IsSucceeded)
                {
                    TempData[InfoMessage] = "رمز عبور شما تغییر کرد ، مجدداً وارد شوید";
                    TempData[SuccessMessage] = result.Message;
                    return RedirectToAction("Login", "Account", new { area = "" });
                }

                TempData[ErrorMessage] = result.Message;
            }

            return View(command);
        }

        [HttpGet("Change-Profile")]
        public async Task<IActionResult> ChangeProfile() => View(await _userApplication.GetDetailForEditBy(User.GetUserId()));

        [HttpPost("Change-Profile")]
        public async Task<IActionResult> ChangeProfile(EditUserVM command)
        {
            if (!await _captchaValidator.IsCaptchaPassedAsync(command.Captcha))
            {
                TempData[ErrorMessage] = "کپچای شما تایید نشد";
                return View(command);
            }

            if (ModelState.IsValid)
            {
                var result = await _userApplication.Edit(command);

                if (result.IsSucceeded)
                {
                    TempData[SuccessMessage] = result.Message;
                    TempData[InfoMessage] = "پیشنهاد می شود مجدداً وارد شوید";
                    return RedirectToAction("ChangeProfile");
                }

                TempData[ErrorMessage] = result.Message;
            }

            return View(command);
        }
    }
}