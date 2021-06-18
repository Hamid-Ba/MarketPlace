using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MarketPlace.ApplicationContract.AI.Account;
using MarketPlace.ApplicationContract.ViewModels.Account;

namespace ServiceHost.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUserApplication _userApplication;

        public AccountController(IUserApplication userApplication) => _userApplication = userApplication;

        [HttpGet]
        public IActionResult Register() => User.Identity != null && User.Identity.IsAuthenticated ? RedirectToAction("Index","Home") : View();

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
                    return RedirectToAction("Index", "Home");
                }

                TempData[ErrorMessage] = result.Message;
            }
            return View(command);
        }

        [HttpGet]
        public IActionResult Login() => User.Identity != null && User.Identity.IsAuthenticated ? RedirectToAction("Index", "Home") : View();

        [HttpPost]
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
    }
}
