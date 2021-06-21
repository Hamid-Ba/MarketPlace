using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GoogleReCaptcha.V3;
using MarketPlace.ApplicationContract.AI.Account;
using MarketPlace.ApplicationContract.ViewModels.Account;

namespace ServiceHost.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUserApplication _userApplication;

        public AccountController(IUserApplication userApplication) => _userApplication = userApplication;

        [HttpGet]
        public IActionResult Register() => User.Identity != null && User.Identity.IsAuthenticated ? RedirectToAction("Index", "Home") : View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserVM command)
        {
            if (ModelState.IsValid)
            {
                var result = await _userApplication.Register(command);

                if (result.IsSucceeded)
                {
                    TempData[SuccessMessage] = result.Message;
                    TempData[InfoMessage] = "جهت تکمیل ثبت نام کد فعال سازی برای شما ارسال شد";
                    return RedirectToAction("ActiveAccount",new {mobile = command.Mobile});
                }

                TempData[ErrorMessage] = result.Message;
            }
            return View(command);
        }

        [HttpGet]
        public IActionResult ActiveAccount(string mobile)
        {
            if (!string.IsNullOrEmpty(mobile))
            {
                ViewBag.Mobile = mobile;
                return User.Identity != null && User.Identity.IsAuthenticated ? RedirectToAction("Index", "Home") : View();
            }

            return RedirectToAction("Register");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ActiveAccount(ActiveMobileUserVM command)
        {
            if (ModelState.IsValid)
            {
                var result = await _userApplication.ActiveUserAccount(command);

                if (result.IsSucceeded)
                {
                    TempData[SuccessMessage] = result.Message;
                    return RedirectToAction("Login");
                }

                TempData[ErrorMessage] = result.Message;
            }

            return RedirectToAction("ActiveAccount", new { mobile = command.Mobile });
        }

        [HttpGet]
        public IActionResult Login() => User.Identity != null && User.Identity.IsAuthenticated ? RedirectToAction("Index", "Home") : View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserVM command)
        {
            if (ModelState.IsValid)
            {
                var result = await _userApplication.Login(command);

                if (result.IsSucceeded)
                {
                    TempData[SuccessMessage] = result.Message;
                    return RedirectToAction("Index", "Home");
                }

                TempData[ErrorMessage] = result.Message;
            }

            return View(command);
        }

        public IActionResult Logout()
        {
            var result = _userApplication.Logout();

            if (result.IsSucceeded)
            {
                TempData[SuccessMessage] = result.Message;
                return RedirectToAction("Login", "Account");
            }

            TempData[ErrorMessage] = result.Message;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ForgotPassword() => User.Identity != null && User.Identity.IsAuthenticated ? RedirectToAction("Index", "Home") : View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordUserVM command)
        {
            if (ModelState.IsValid)
            {
                var result = await _userApplication.ForgotPassword(command);

                if (result.IsSucceeded)
                {
                    TempData[InfoMessage] = result.Message;
                    return RedirectToAction("RecoverPassword", new { mobile = command.Mobile });
                }

                TempData[ErrorMessage] = result.Message;
            }
            return View(command);
        }

        [HttpGet]
        public IActionResult RecoverPassword(string mobile)
        {
            if (!string.IsNullOrEmpty(mobile))
            {
                ViewBag.Mobile = mobile;
                return User.Identity != null && User.Identity.IsAuthenticated ? RedirectToAction("Index", "Home") : View();
            }

            return RedirectToAction("ForgotPassword");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> RecoverPassword(RecoverPasswordUserVM command)
        {
            if (ModelState.IsValid)
            {
                var result = await _userApplication.RecoverPassword(command);

                if (result.IsSucceeded)
                {
                    TempData[SuccessMessage] = result.Message;
                    TempData[InfoMessage] = "رمز عبور جدید برای شما ارسال شد ، لطفا پس از ورود به حساب خود آن را تغییر دهید";
                    return RedirectToAction("Login");
                }

                TempData[ErrorMessage] = result.Message;
            }

            return RedirectToAction("RecoverPassword", new {mobile = command.Mobile});
        }
    }
}