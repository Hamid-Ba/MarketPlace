using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ServiceHost.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class UserBaseController : Controller
    {
    }
}
