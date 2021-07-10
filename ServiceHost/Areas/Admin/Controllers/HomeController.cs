using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
