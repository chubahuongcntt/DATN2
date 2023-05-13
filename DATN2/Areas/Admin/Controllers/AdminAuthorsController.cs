using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DATN2.Models;
using PagedList.Core;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;

namespace DATN2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AdminAuthorsController : Controller
    {
        private readonly BookStore2Context _context;
        public INotyfService _notyfService { get; }
        public AdminAuthorsController(BookStore2Context context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/AdminAuthors
        
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 10;
            var lsAuthor = _context.Authors
                .AsNoTracking()
                .OrderByDescending(x => x.Id);
            PagedList<Author> models = new PagedList<Author>(lsAuthor, pageNumber, pageSize);

            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }
        // GET: Admin/AdminAuthors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var author = await _context.Authors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // GET: Admin/AdminAuthors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminAuthors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,Story")] Author author)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(author);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Thêm tác giả thành công");
                    return RedirectToAction(nameof(Index));
                }
                _notyfService.Error("Thêm tác giả không thành công");
                return View(author);
            }
            catch
            {
                _notyfService.Error("Thêm tác giả không thành công");
                return View(author);
            }
        }

        // GET: Admin/AdminAuthors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: Admin/AdminAuthors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,Story")] Author author)
        {
            try
            {
                if (id != author.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(author);
                        await _context.SaveChangesAsync();
                        _notyfService.Success("Sửa tác giả thành công");
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        _notyfService.Error("Sửa tác giả không thành công");
                        if (!AuthorExists(author.Id))
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
                _notyfService.Error(" Sửa tác giả không thành công");
                return View(author);
            }
            catch
            {
                _notyfService.Error(" Sửa tác giả không thành công");
                return View(author);
            }
        }

        // GET: Admin/AdminAuthors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var author = await _context.Authors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: Admin/AdminAuthors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (_context.Authors == null)
                {
                    return Problem("Entity set 'BookStore2Context.Authors'  is null.");
                }
                var author = await _context.Authors.FindAsync(id);
                if (author != null)
                {
                    _context.Authors.Remove(author);
                }

                await _context.SaveChangesAsync();
                _notyfService.Success("Xóa tác giả thành công");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                _notyfService.Error("Tác giả đã được sử dụng xóa không thành công");
                return RedirectToAction(nameof(Index));
            }
        }

        private bool AuthorExists(int id)
        {
          return (_context.Authors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
