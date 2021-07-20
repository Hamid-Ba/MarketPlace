using System.Threading.Tasks;
using Framework.Application;
using Microsoft.AspNetCore.Mvc;
using Framework.Application.Authentication;
using MarketPlace.ApplicationContract.AI.PictureAgg;
using MarketPlace.ApplicationContract.AI.ProductAgg;
using MarketPlace.ApplicationContract.AI.StoreAgg;
using MarketPlace.ApplicationContract.ViewModels.PictureAgg;
using MarketPlace.ApplicationContract.ViewModels.ProductAgg;
using MarketPlace.Query.Contract.Category;
using MarketPlace.Query.Contract.Picture;
using MarketPlace.Query.Contract.Product;

namespace ServiceHost.Areas.Store.Controllers
{
    public class ProductController : StoreBaseController
    {
        private readonly IProductQuery _productQuery;
        private readonly IPictureQuery _pictureQuery;
        private readonly ICategoryQuery _categoryQuery;
        private readonly IStoreApplication _storeApplication;
        private readonly IProductApplication _productApplication;
        private readonly IPictureApplication _pictureApplication;

        public ProductController(IStoreApplication storeApplication, IProductQuery productQuery, ICategoryQuery categoryQuery, IProductApplication productApplication, IPictureQuery pictureQuery, IPictureApplication pictureApplication)
        {
            _storeApplication = storeApplication;
            _productQuery = productQuery;
            _categoryQuery = categoryQuery;
            _productApplication = productApplication;
            _pictureQuery = pictureQuery;
            _pictureApplication = pictureApplication;
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

        [HttpGet("pictures/{productId}")]
        public async Task<IActionResult> Pictures(long productId)
        {
            var isProductConfirmed = await _productApplication.IsProductConfirmed(productId);

            if (!isProductConfirmed.IsSucceeded)
            {
                TempData[WarningMessage] = isProductConfirmed.Message;
                return RedirectToAction("Dashboard", "Home", new { area = "User" });
            }

            var result = await _productApplication.IsProductBelongToUser(productId, User.GetUserId());

            ViewBag.ProductId = productId;
            ViewBag.StoreId = _productApplication.GetStoreIdBy(productId);
            if (result) return View(await _pictureQuery.GetPicturesBy(productId));

            TempData[ErrorMessage] = ApplicationMessage.DoNotAccessToOtherStore;
            return RedirectToAction("Dashboard", "Home", new { area = "User" });
        }

        public async Task<IActionResult> AddPicture(long productId)
        {
            var isProductConfirmed = await _productApplication.IsProductConfirmed(productId);

            if (!isProductConfirmed.IsSucceeded)
            {
                TempData[WarningMessage] = isProductConfirmed.Message;
                return RedirectToAction("Dashboard", "Home", new { area = "User" });
            }

            var result = await _productApplication.IsProductBelongToUser(productId, User.GetUserId());

            ViewBag.ProductId = productId;
            ViewBag.StoreId = _productApplication.GetStoreIdBy(productId);
            if (result) return View(new CreatePictureVM() { ProductId = productId });

            TempData[ErrorMessage] = ApplicationMessage.DoNotAccessToOtherStore;
            return RedirectToAction("Dashboard", "Home", new { area = "User" });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPicture(CreatePictureVM command)
        {
            var check = await _productApplication.IsProductBelongToUser(command.ProductId, User.GetUserId());

            if (!check)
            {
                TempData[ErrorMessage] = ApplicationMessage.DoNotAccessToOtherStore;
                return RedirectToAction("Dashboard", "Home", new {area = "User"});
            }

            if (ModelState.IsValid)
            {
                command.UserId = User.GetUserId();
                var result = await _pictureApplication.Create(command);

                if (result.IsSucceeded)
                {
                    TempData[SuccessMessage] = result.Message;
                    return RedirectToAction("Pictures", new { productId = command.ProductId });
                }

                TempData[ErrorMessage] = result.Message;
            }

            ViewBag.StoreId = _productApplication.GetStoreIdBy(command.ProductId);
            ViewBag.ProductId = command.ProductId;
            return View(command);
        }

        [HttpGet]
        public async Task<IActionResult> EditPicture(long id, long productId)
        {
            var isProductConfirmed = await _productApplication.IsProductConfirmed(productId);

            if (!isProductConfirmed.IsSucceeded)
            {
                TempData[WarningMessage] = isProductConfirmed.Message;
                return RedirectToAction("Dashboard", "Home", new { area = "User" });
            }

            var picture = await _pictureApplication.GetDetailForEditBy(id, productId);
            ViewBag.StoreId = _productApplication.GetStoreIdBy(productId);
            ViewBag.ProductId = productId;
            if (picture != null) return View(picture);

            TempData[ErrorMessage] = ApplicationMessage.DoNotAccessToOtherStore;
            return RedirectToAction("Dashboard", "Home", new { area = "User" });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPicture(EditPictureVM command)
        {
            if (ModelState.IsValid)
            {
                command.UserId = User.GetUserId();
                var result = await _pictureApplication.Edit(command);

                if (result.IsSucceeded)
                {
                    TempData[SuccessMessage] = result.Message;
                    return RedirectToAction("Pictures", new { productId = command.ProductId });
                }

                TempData[ErrorMessage] = result.Message;
            }

            ViewBag.StoreId = _productApplication.GetStoreIdBy(command.ProductId);
            ViewBag.ProductId = command.ProductId;
            return View(command);
        }

    }
}