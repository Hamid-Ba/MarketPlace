using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ServiceHost.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class AdminBaseController : Controller
    {
        protected string ErrorMessage = "ErrorMessage";
        protected string SuccessMessage = "SuccessMessage";
        protected string InfoMessage = "InfoMessage";
        protected string WarningMessage = "WarningMessage";
    }
}
