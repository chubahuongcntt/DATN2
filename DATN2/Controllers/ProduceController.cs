using DATN2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult Index(string searchText = "", int CatID = 0)
        {
            List<Produce> produces = new List<Produce>();
            if (searchText != null && searchText != "")
            {
                produces = _context.Produces.Where(x => x.Name.Contains(searchText))
                    .AsNoTracking().OrderByDescending(x => x.Datecreate).ToList();
            }
            else
            {
                produces = _context.Produces.AsNoTracking()
                    .OrderByDescending(x => x.Datecreate).ToList();
            }
            if(CatID != 0)
            {
                produces = _context.Produces.Where(x => x.CatId == CatID)
                    .AsNoTracking().OrderByDescending(x => x.Datecreate).ToList();
            }
            ViewData["DanhMuc"] = new SelectList(_context.Categories, "Id", "Name");
            return View(produces);
        }
        public IActionResult SapXep(int? id)
        {
            List<Produce> produces = new List<Produce>();
            if (id == 1)
            {
                produces = _context.Produces
                    .AsNoTracking().OrderBy(x => x.Discount).ToList();
            }
            if (id == 2)
            {
                produces = _context.Produces
                    .AsNoTracking().OrderByDescending(x => x.Discount).ToList();
            }
            if (id == 3)
            {
                produces = _context.Produces
                    .AsNoTracking().OrderBy(x => x.Datecreate).ToList();
            }
            if (id == 4)
            {
                produces = _context.Produces
                    .AsNoTracking().OrderByDescending(x => x.Datecreate).ToList();
            }
            if (id == 5)
            {
                produces = _context.Produces.Where(x=>x.BestSell == true)
                    .AsNoTracking().ToList();
            }
            if (id == 6)
            {
                produces = _context.Produces.Where(x => x.Discount >= 20000 && x.Discount <=40000)
                    .AsNoTracking().ToList();
            }
            ViewData["DanhMuc"] = new SelectList(_context.Categories, "Id", "Name");
            return View(produces);
        }
        public IActionResult Filtter(int CatID = 0)
        {
            var url = $"/Produce/Index?CatID={CatID}";
            if (CatID == 0)
            {
                url = $"/Produce/Index";
            }
            return Json(new { status = "success", redirectUrl = url });
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
                ViewData["DanhMuc"] = new SelectList(_context.Categories, "Id", "Name");
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
