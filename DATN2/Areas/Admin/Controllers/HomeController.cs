using AspNetCoreHero.ToastNotification.Abstractions;
using DATN2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DATN2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly BookStore2Context _context;
        public HomeController(BookStore2Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Order = _context.Orders.Count();
            ViewBag.Produce = _context.Produces.Count();
            ViewBag.Category = _context.Categories.Count();
            ViewBag.Author = _context.Authors.Count();
            ViewBag.Customer = _context.Customers.Count();
            return View();
        }
    }
}
