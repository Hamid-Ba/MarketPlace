using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Framework.Application;
using MarketPlace.ApplicationContract.AI.StoreAgg;
using MarketPlace.ApplicationContract.ViewModels.StoreAgg;

namespace ServiceHost.Areas.Admin.Controllers
{
    public class StoreController : AdminBaseController
    {
        private readonly IStoreApplication _storeApplication;

        public StoreController(IStoreApplication storeApplication) => _storeApplication = storeApplication;

        [HttpGet("Requests-List")]
        public async Task<IActionResult> ListOfRequests() => View(await _storeApplication.GetAllForAdmin());

        [HttpGet("Confirm-Request")]
        public IActionResult Confirm(long id) => PartialView("Confirm", id);

        [HttpPost("Confirm-Request"), ValidateAntiForgeryToken]
        [Route("Confirm")]
        public async Task<IActionResult> ConfirmRequest(long id)
        {
            var result = await _storeApplication.ConfirmStoreRequestBy(id);

            if (result.IsSucceeded) TempData[SuccessMessage] = result.Message;

            return new JsonResult(result);
        }

        [HttpGet("DissConfirm-Request")]
        public IActionResult DissConfirm(long id) => PartialView("DissConfirm", new DissConfrimStoreRequestVM() { Id = id });

        [HttpPost("DissConfirm-Request"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DissConfirm(DissConfrimStoreRequestVM command)
        {
            command.Status = StoreStatus.Rejected;

            var result = await _storeApplication.DissConfirmStoreRequestBy(command);

            if (result.IsSucceeded) TempData[SuccessMessage] = result.Message;

            return new JsonResult(result);
        }

    }
}
