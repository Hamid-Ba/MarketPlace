using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MarketPlace.ApplicationContract.AI.ProductAgg;

namespace ServiceHost.Areas.Admin.Controllers
{
    public class ProductController : AdminBaseController
    {
        private readonly IProductApplication _productApplication;

        public ProductController(IProductApplication productApplication) => _productApplication = productApplication;

        [HttpGet("Products-List")]
        public async Task<IActionResult> ListOfProducts() => View(await _productApplication.GetAllForAdmin());

        [HttpGet("Confirm-Product")]
        public IActionResult Confirm(long id) => PartialView("Confirm", id);

        [HttpPost("Confirm-Product"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Confirm(long id, string reason)
        {
            var result = await _productApplication.ConfirmOrDissConfirm(id, true, reason);
            if (result.IsSucceeded) TempData[SuccessMessage] = result.Message;
            return new JsonResult(result);
        }

        [HttpGet("DissConfirm-Product")]
        public IActionResult DissConfirm(long id) => PartialView("DissConfirm", id);

        [HttpPost("DissConfirm-Product"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DissConfirm(long id, string reason)
        {
            var result = await _productApplication.ConfirmOrDissConfirm(id, false, reason);
            if (result.IsSucceeded) TempData[SuccessMessage] = result.Message;
            return new JsonResult(result);
        }
    }
}
