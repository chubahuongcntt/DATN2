using DATN2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DATN2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SearchController : Controller
    {
        private readonly BookStore2Context _context;

        public SearchController(BookStore2Context context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult FindProduce(string keyword)
        {
            List<Produce> ls = new List<Produce>();
            if (string.IsNullOrEmpty(keyword) || keyword.Length < 1)
            {
                return RedirectToAction(nameof(Index));
            }
            ls = _context.Produces.AsNoTracking()
                                  .Include(a => a.Cat)
                                  .Where(x => x.Name.Contains(keyword))
                                  .OrderByDescending(x => x.Name)
                                  .Take(10)
                                  .ToList();
            if (ls == null)
            {
                return PartialView("ListProducesSearchPartial", null);
            }
            else
            {
                return PartialView("ListProducesSearchPartial", ls);
            }
        }
        public IActionResult FindAuthor(string keyword)
        {
            List<Author> ls = new List<Author>();
            if (string.IsNullOrEmpty(keyword) || keyword.Length < 1)
            {
                return RedirectToAction(nameof(Index));
            }
            ls = _context.Authors.AsNoTracking()
                                  .Where(x => x.Name.Contains(keyword))
                                  .OrderByDescending(x => x.Name)
                                  .Take(10)
                                  .ToList();
            if (ls == null)
            {
                return PartialView("ListAuthorSearchPartial", null);
            }
            else
            {
                return PartialView("ListAuthorSearchPartial", ls);
            }
        }

    }
}
