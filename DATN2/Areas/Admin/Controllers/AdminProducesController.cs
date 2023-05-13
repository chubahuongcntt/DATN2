using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DATN2.Models;
using PagedList.Core;
using DATN2.Helpper;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;

namespace DATN2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AdminProducesController : Controller
    {
        private readonly BookStore2Context _context;
        public INotyfService _notyfService { get; }
        public AdminProducesController(BookStore2Context context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
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
                .OrderBy(x => x.Name).ToList();
            }
            else
            {
                lsproduces = _context.Produces
                .AsNoTracking()
                .Include(x => x.Cat)
                .OrderBy(x => x.Name).ToList();
            }
            PagedList<Produce> models = new PagedList<Produce>(lsproduces.AsQueryable(), pageNumber, pageSize);
            ViewBag.CurrentCateID = CatID;
            ViewBag.CurrentPage = pageNumber;
            ViewData["DanhMuc"] = new SelectList(_context.Categories, "Id", "Name");
            ViewBag.TongSL = _context.Produces.Sum(x => x.UnitslnStock);
            ViewBag.TongSLDB = _context.OrderDetails.Sum(x => x.Quantity);
            return View(models);
        }

        public IActionResult Filtter(int CatID = 0)
        {
            var url = $"/Admin/AdminProduces/Index?CatID={CatID}";
            if (CatID == 0)
            {
                url = $"/Admin/AdminProduces/Index";
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
        public async Task<IActionResult> Create([Bind("Id,Name,Desciption,CatId,AutId,Price,Discount,Thumb,BestSell,HomeFlag,Active,Tag,UnitslnStock,Datecreate,Alias,NhaXb")] Produce produce, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            try
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
                    produce.Alias = Utilities.SEOUrl(produce.Name);
                    produce.Datecreate = DateTime.Now;
                    _context.Add(produce);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Thêm mới thành công");
                    return RedirectToAction(nameof(Index));
                }
                ViewData["AutId"] = new SelectList(_context.Authors, "Id", "Name", produce.AutId);
                ViewData["CatId"] = new SelectList(_context.Categories, "Id", "Name", produce.CatId);
                return View(produce);
            }
            catch
            {
                return RedirectToAction(nameof(Create));
            }
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Desciption,CatId,AutId,Price,Discount,Thumb,BestSell,HomeFlag,Active,Tag,UnitslnStock,Datecreate,Alias,NhaXb")] Produce produce, Microsoft.AspNetCore.Http.IFormFile fThumb)
        {
            try
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
                        produce.Alias = Utilities.SEOUrl(produce.Name);

                        _context.Update(produce);
                        _notyfService.Success("Cập nhật thành công");
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
            catch
            {
                ViewData["AutId"] = new SelectList(_context.Authors, "Id", "Name", produce.AutId);
                ViewData["CatId"] = new SelectList(_context.Categories, "Id", "Name", produce.CatId);
                return View(produce);
            }
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
            try
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
                _notyfService.Success("Xóa thành công");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                _notyfService.Error("Sách đã có trong đơn hàng xóa không thành công");
                return RedirectToAction(nameof(Index));
            }
        }

        private bool ProduceExists(int id)
        {
          return (_context.Produces?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
