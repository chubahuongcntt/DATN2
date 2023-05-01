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
    public class AdminCategoriesController : Controller
    {
        private readonly BookStore2Context _context;
        public INotyfService _notyfService { get; }
        public AdminCategoriesController(BookStore2Context context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/AdminCategories
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 10;
            var lsCategorys = _context.Categories
                .AsNoTracking()
                .OrderByDescending(x => x.Id);
            PagedList<Category> models = new PagedList<Category>(lsCategorys, pageNumber, pageSize);

            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }

        // GET: Admin/AdminCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Admin/AdminCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,ParentId,Levels,Odering,Published,Thums,Title,Cover,Alias")] Category category, Microsoft.AspNetCore.Http.IFormFile fThums)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    category.Name = Utilities.ToTitleCase(category.Name);
                    if (fThums != null)
                    {
                        string extension = Path.GetExtension(fThums.FileName);
                        string image = Utilities.SEOUrl(category.Name) + extension;
                        category.Thums = await Utilities.UploadFile(fThums, @"category", image.ToLower());
                    }
                    if (string.IsNullOrEmpty(category.Thums)) category.Thums = "default.jpg";
                    category.Alias = Utilities.SEOUrl(category.Name);
                    _context.Add(category);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Thêm mới thành công");
                    return RedirectToAction(nameof(Index));
                }
                return View(category);
            }
            catch
            {
                return View(category);
            }
        }

        // GET: Admin/AdminCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Admin/AdminCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ParentId,Levels,Odering,Published,Thums,Title,Cover,Alias")] Category category, Microsoft.AspNetCore.Http.IFormFile fThums)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (fThums != null)
                    {
                        string extension = Path.GetExtension(fThums.FileName);
                        string image = Utilities.SEOUrl(category.Name) + extension;
                        category.Thums = await Utilities.UploadFile(fThums, @"category", image.ToLower());
                    }
                    if (string.IsNullOrEmpty(category.Thums)) category.Thums = "default.jpg";
                    category.Alias = Utilities.SEOUrl(category.Name);
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Cập nhật thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                    if (!CategoryExists(category.Id))
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
            return View(category);
        }

        // GET: Admin/AdminCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Admin/AdminCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Categories == null)
            {
                return Problem("Entity set 'BookStore2Context.Categories'  is null.");
            }
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }
            
            await _context.SaveChangesAsync();
            _notyfService.Success("Xóa thành công");
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
          return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
