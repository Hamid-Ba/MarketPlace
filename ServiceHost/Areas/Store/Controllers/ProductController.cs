using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Framework.Application.Authentication;
using MarketPlace.ApplicationContract.AI.ProductAgg;
using MarketPlace.ApplicationContract.AI.StoreAgg;
using MarketPlace.ApplicationContract.ViewModels.ProductAgg;
using MarketPlace.Query.Contract.Category;
using MarketPlace.Query.Contract.Product;

namespace ServiceHost.Areas.Store.Controllers
{
    public class ProductController : StoreBaseController
    {
        private readonly IProductQuery _productQuery;
        private readonly ICategoryQuery _categoryQuery;
        private readonly IStoreApplication _storeApplication;
        private readonly IProductApplication _productApplication;

        public ProductController(IStoreApplication storeApplication, IProductQuery productQuery, ICategoryQuery categoryQuery, IProductApplication productApplication)
        {
            _storeApplication = storeApplication;
            _productQuery = productQuery;
            _categoryQuery = categoryQuery;
            _productApplication = productApplication;
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
            ViewBag.Categories = await _categoryQuery.GetCategories();
            if (result.IsSucceeded) return View();

            TempData[ErrorMessage] = result.Message;
            return RedirectToAction("Dashboard", "Home", new { area = "User" });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductVM command)
        {
            var check = await _storeApplication.IsStoreBelongToUser(command.StoreId, User.GetUserId());

            if (!check.IsSucceeded)
            {
                TempData[ErrorMessage] = check.Message;
                return RedirectToAction("Dashboard", "Home", new { area = "User" });
            }

            if (ModelState.IsValid)
            {
                var result = await _productApplication.Create(command);

                if (result.IsSucceeded)
                {
                    TempData[SuccessMessage] = result.Message;
                    return RedirectToAction("Products", new { id = command.StoreId });
                }

                TempData[ErrorMessage] = result.Message;
            }

            ViewBag.StoreId = command.StoreId;
            ViewBag.Categories = await _categoryQuery.GetCategories();
            return View("Create", command);
        }

        public async Task<IActionResult> Edit(long id)
        {
            var product = await _productApplication.GetDetailForEditBy(id);

            var result = await _storeApplication.IsStoreBelongToUser(product.StoreId, User.GetUserId());

            ViewBag.Categories = await _categoryQuery.GetCategories();

            if (result.IsSucceeded) return View(product);

            TempData[ErrorMessage] = result.Message;
            return RedirectToAction("Dashboard", "Home", new { area = "User" });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditProductVM command)
        {
            var check = await _storeApplication.IsStoreBelongToUser(command.StoreId, User.GetUserId());

            if (!check.IsSucceeded)
            {
                TempData[ErrorMessage] = check.Message;
                return RedirectToAction("Dashboard", "Home", new { area = "User" });
            }

            if (ModelState.IsValid)
            {
                var result = await _productApplication.Edit(command);

                if (result.IsSucceeded)
                {
                    TempData[SuccessMessage] = result.Message;
                    return RedirectToAction("Products", new { id = command.StoreId });
                }

                TempData[ErrorMessage] = result.Message;
            }

            ViewBag.Categories = await _categoryQuery.GetCategories();
            return View("Edit", command);
        }
    }
}
