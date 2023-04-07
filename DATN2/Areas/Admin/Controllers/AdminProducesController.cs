using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DATN2.Models;
using PagedList.Core;
using WebShop.Helpper;

namespace DATN2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminProducesController : Controller
    {
        private readonly BookStore2Context _context;

        public AdminProducesController(BookStore2Context context)
        {
            _context = context;
        }

        // GET: Admin/AdminProduces
        public IActionResult Index(int page = 1, int CatID = 0)
        {
            var pageNumber = page;
            var pageSize = 10;

            List<Produce> lsproduces = new List<Produce>();
            if (CatID != 0)
            {
                lsproduces = _context.Produces
                .AsNoTracking()
                .Where(x => x.CatId == CatID)
                .Include(x => x.Cat)
                .OrderBy(x => x.Id).ToList();
            }
            else
            {
                lsproduces = _context.Produces
                .AsNoTracking()
                .Include(x => x.Cat)
                .OrderBy(x => x.Id).ToList();
            }



            PagedList<Produce> models = new PagedList<Produce>(lsproduces.AsQueryable(), pageNumber, pageSize);
            ViewBag.CurrentCateID = CatID;

            ViewBag.CurrentPage = pageNumber;

            ViewData["DanhMuc"] = new SelectList(_context.Categories, "Id", "Name");

            return View(models);
        }
        public IActionResult Filtter(int CatID = 0)
        {
            var url = $"/Admin/AdminProduces?CatID={CatID}";
            if (CatID == 0)
            {
                url = $"/Admin/AdminProduces";
            }
            return Json(new { status = "success", redirectUrl = url });
        }
        // GET: Admin/AdminProduces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produces == null)
            {
                return NotFound();
            }

            var produce = await _context.Produces
                .Include(p => p.Aut)
                .Include(p => p.Cat)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produce == null)
            {
                return NotFound();
            }

            return View(produce);
        }
        
        // GET: Admin/AdminProduces/Create
        public IActionResult Create()
        {
            ViewData["AutId"] = new SelectList(_context.Authors, "Id", "Name");
            ViewData["CatId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Admin/AdminProduces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Desciption,CatId,AutId,Price,Discount,Thumb,BestSell,HomeFlag,Active,Tag,UnitslnStock")] Produce produce, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            if (ModelState.IsValid)
            {
                produce.Name = Utilities.ToTitleCase(produce.Name);
                if (fThumb != null)
                {
                    string extension = Path.GetExtension(fThumb.FileName);
                    string image = Utilities.SEOUrl(produce.Name) + extension;
                    produce.Thumb = await Utilities.UploadFile(fThumb, @"produces", image.ToLower());
                }
                if (string.IsNullOrEmpty(produce.Thumb)) produce.Thumb = "default.jpg";

                _context.Add(produce);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutId"] = new SelectList(_context.Authors, "Id", "Name", produce.AutId);
            ViewData["CatId"] = new SelectList(_context.Categories, "Id", "Name", produce.CatId);
            return View(produce);
        }

        // GET: Admin/AdminProduces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produces == null)
            {
                return NotFound();
            }

            var produce = await _context.Produces.FindAsync(id);
            if (produce == null)
            {
                return NotFound();
            }
            ViewData["AutId"] = new SelectList(_context.Authors, "Id", "Name", produce.AutId);
            ViewData["CatId"] = new SelectList(_context.Categories, "Id", "Name", produce.CatId);
            return View(produce);
        }

        // POST: Admin/AdminProduces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Desciption,CatId,AutId,Price,Discount,Thumb,BestSell,HomeFlag,Active,Tag,UnitslnStock")] Produce produce, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            if (id != produce.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    produce.Name = Utilities.ToTitleCase(produce.Name);
                    if (fThumb != null)
                    {
                        string extension = Path.GetExtension(fThumb.FileName);
                        string image = Utilities.SEOUrl(produce.Name) + extension;
                        produce.Thumb = await Utilities.UploadFile(fThumb, @"produces", image.ToLower());
                    }
                    if (string.IsNullOrEmpty(produce.Thumb)) produce.Thumb = "default.jpg";


                    _context.Update(produce);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduceExists(produce.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutId"] = new SelectList(_context.Authors, "Id", "Name", produce.AutId);
            ViewData["CatId"] = new SelectList(_context.Categories, "Id", "Name", produce.CatId);
            return View(produce);
        }

        // GET: Admin/AdminProduces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produces == null)
            {
                return NotFound();
            }

            var produce = await _context.Produces
                .Include(p => p.Aut)
                .Include(p => p.Cat)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produce == null)
            {
                return NotFound();
            }

            return View(produce);
        }

        // POST: Admin/AdminProduces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produces == null)
            {
                return Problem("Entity set 'BookStore2Context.Produces'  is null.");
            }
            var produce = await _context.Produces.FindAsync(id);
            if (produce != null)
            {
                _context.Produces.Remove(produce);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduceExists(int id)
        {
          return (_context.Produces?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
