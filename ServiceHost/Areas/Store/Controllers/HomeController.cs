using System.Threading.Tasks;
using Framework.Application.Authentication;
using MarketPlace.ApplicationContract.AI.StoreAgg;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Store.Controllers
{
    public class HomeController : StoreBaseController
    {
        private readonly IStoreApplication _storeApplication;

        public HomeController(IStoreApplication storeApplication) => _storeApplication = storeApplication;

        public async Task<IActionResult> Index(long id)
        {
            var result = await _storeApplication.IsStoreBelongToUser(id, User.GetUserId());

            if (result.IsSucceeded) return View();

            TempData[ErrorMessage] = result.Message;
            return RedirectToAction("Dashboard", "Home", new { area = "User" });
        }
    }
}
