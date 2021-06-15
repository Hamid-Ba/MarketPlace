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
        public IActionResult Register() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserVM command)
        {
            if (ModelState.IsValid)
            {
                var result = await _userApplication.Register(command);

                if (result.IsSucceeded)
                {
                    TempData[SuccessMessage] = result.Message;
                    return RedirectToAction("Index", "Home");
                }

                TempData[ErrorMessage] = result.Message;
            }
            return View(command);
        }
    }
}
