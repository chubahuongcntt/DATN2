using Microsoft.AspNetCore.Mvc;

namespace DATN2.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
