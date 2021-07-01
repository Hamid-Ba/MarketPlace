using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.User.Controllers
{
    public class HomeController : UserBaseController
    {
        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
