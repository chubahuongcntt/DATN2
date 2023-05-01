using DATN2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;

namespace DATN2.Controllers
{
    public class ProduceController : Controller
    {
        private readonly BookStore2Context _context;
        public ProduceController(BookStore2Context context)
        {
            _context = context;
        }
        public IActionResult Index(int? page)
        {
            try
            {
                var pageNumber = page == null || page <= 0 ? 1 : page.Value;
                var pageSize = 80;
                var lsproduces = _context.Produces
                    .AsNoTracking()
                    .OrderBy(x => x.Name);
                PagedList<Produce> models = new PagedList<Produce>(lsproduces, pageNumber, pageSize);

                ViewBag.CurrentPage = pageNumber;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [Route("danhmuc/{Alias}", Name = ("ListProduce"))]
        public IActionResult List(string Alias, int page = 1)
        {
            try
            {
                var pageSize = 80;
                var danhmuc = _context.Categories.AsNoTracking().SingleOrDefault(x => x.Alias == Alias);

                var lsTinDangs = _context.Produces
                    .AsNoTracking()
                    .Where(x => x.CatId == danhmuc.Id)
                    .OrderByDescending(x => x.Datecreate);
                PagedList<Produce> models = new PagedList<Produce>(lsTinDangs, page, pageSize);
                ViewBag.CurrentPage = page;
                ViewBag.CurrentCat = danhmuc;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [Route("/{Alias}-{id}.html", Name = ("ProduceDetails"))]
        public IActionResult Details(int id)
        {
            try
            {
                var Produce = _context.Produces.Include(x => x.Cat).FirstOrDefault(x => x.Id == id);
                if (Produce == null)
                {
                    return RedirectToAction("Index");
                }
                var lsProduce = _context.Produces
                    .AsNoTracking()
                    .Where(x => x.CatId == Produce.CatId && x.Id != id && x.Active == true)
                    .Take(4)
                    .OrderByDescending(x => x.Datecreate)
                    .ToList();
                ViewBag.SanPham = lsProduce;
                return View(Produce);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
