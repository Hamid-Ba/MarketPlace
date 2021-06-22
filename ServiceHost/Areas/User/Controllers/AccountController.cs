using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost.Areas.User.Controllers
{
    public class AccountController : UserBaseController
    {

        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
