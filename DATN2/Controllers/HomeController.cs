using DATN2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using DATN2.ModelViews;

namespace DATN2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookStore2Context _context;
        public HomeController(ILogger<HomeController> logger, BookStore2Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            HomeViewVM model = new HomeViewVM();

            var lsProduces = _context.Produces.AsNoTracking()
                .Where(x => x.Active == true && x.HomeFlag == true)
                .OrderByDescending(x => x.Name)
                .ToList();

            List<ProduceHomeVM> lsProductViews = new List<ProduceHomeVM>();
            var lsCats = _context.Categories
                .AsNoTracking()
                .Where(x => x.Published == true)
                .OrderByDescending(x => x.Odering)
                .ToList();

            foreach (var item in lsCats)
            {
                ProduceHomeVM productHome = new ProduceHomeVM();
                productHome.category = item;
                productHome.lsProduces = lsProduces.Where(x => x.CatId == item.Id).ToList();
                lsProductViews.Add(productHome);
                model.Produces = lsProductViews;
                ViewBag.AllProducts = lsProduces;
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}