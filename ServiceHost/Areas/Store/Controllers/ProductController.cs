using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Framework.Application.Authentication;
using MarketPlace.ApplicationContract.AI.StoreAgg;
using MarketPlace.Query.Contract.Category;
using MarketPlace.Query.Contract.Product;

namespace ServiceHost.Areas.Store.Controllers
{
    public class ProductController : StoreBaseController
    {
        private readonly IProductQuery _productQuery;
        private readonly ICategoryQuery _categoryQuery;
        private readonly IStoreApplication _storeApplication;

        public ProductController(IStoreApplication storeApplication, IProductQuery productQuery, ICategoryQuery categoryQuery)
        {
            _storeApplication = storeApplication;
            _productQuery = productQuery;
            _categoryQuery = categoryQuery;
        }

        public async Task<IActionResult> Products(long id)
        {
            var result = await _storeApplication.IsStoreBelongToUser(id, User.GetUserId());

            ViewBag.StoreId = id;
            if (result.IsSucceeded) return View(await _productQuery.GetStoreProducts(id));

            TempData[ErrorMessage] = result.Message;
            return RedirectToAction("Dashboard", "Home", new { area = "User" });
        }

        public async Task<IActionResult> Create(long id)
        {
            var result = await _storeApplication.IsStoreBelongToUser(id, User.GetUserId());

            ViewBag.StoreId = id;
            ViewBag.Categories = await _categoryQuery.GetForAddProduct();
            if (result.IsSucceeded) return View();

            TempData[ErrorMessage] = result.Message;
            return RedirectToAction("Dashboard", "Home", new { area = "User" });
        }
    }
}
