using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Framework.Application.Authentication;
using MarketPlace.ApplicationContract.AI.StoreAgg;

namespace ServiceHost.Areas.Store.Controllers
{
    public class ProductController : StoreBaseController
    {
        private readonly IStoreApplication _storeApplication;

        public ProductController(IStoreApplication storeApplication) => _storeApplication = storeApplication;

        public async Task<IActionResult> Products(long id)
        {
            var result = await _storeApplication.IsStoreBelongToUser(id, User.GetUserId());

            if (result.IsSucceeded) return View();

            TempData[ErrorMessage] = result.Message;
            return RedirectToAction("Dashboard", "Home", new { area = "User" });
        }
    }
}
