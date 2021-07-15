using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Framework.Application.Authentication;
using MarketPlace.ApplicationContract.AI.StoreAgg;
using MarketPlace.Query.Contract.Product;

namespace ServiceHost.Areas.Store.Controllers
{
    public class ProductController : StoreBaseController
    {
        private readonly IProductQuery _productQuery;
        private readonly IStoreApplication _storeApplication;

        public ProductController(IStoreApplication storeApplication, IProductQuery productQuery)
        {
            _storeApplication = storeApplication;
            _productQuery = productQuery;
        }

        public async Task<IActionResult> Products(long id)
        {
            var result = await _storeApplication.IsStoreBelongToUser(id, User.GetUserId());

            ViewBag.StoreId = id;
            if (result.IsSucceeded) return View(await _productQuery.GetStoreProducts(id));

            TempData[ErrorMessage] = result.Message;
            return RedirectToAction("Dashboard", "Home", new { area = "User" });
        }
    }
}
