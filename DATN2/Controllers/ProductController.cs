using Microsoft.AspNetCore.Mvc;

namespace DATN2.Controllers
{
    public class ProductController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
