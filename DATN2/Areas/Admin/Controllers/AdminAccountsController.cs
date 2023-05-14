using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DATN2.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using DATN2.Areas.Admin.Models;
using DATN2.Extension;
using Microsoft.AspNetCore.Authorization;
using DATN2.Helpper;

namespace DATN2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminAccountsController : Controller
    {
        private readonly BookStore2Context _context;
        public INotyfService _notyfService { get; }
        public AdminAccountsController(BookStore2Context context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/AdminAccounts
        public async Task<IActionResult> Index()
        {
            ViewData["QuyenTruyCap"] = new SelectList(_context.Roles, "Id", "Description");
            List<SelectListItem> IsTrangThai = new List<SelectListItem>();
            IsTrangThai.Add(new SelectListItem() { Text = "Active", Value = "1" });
            IsTrangThai.Add(new SelectListItem() { Text = "Block", Value = "0" });
            ViewData["IsTrangThai"] = IsTrangThai;
            var bookStore2Context = _context.Accounts.Include(a => a.Role);
            return View(await bookStore2Context.ToListAsync());
        }

        // GET: Admin/AdminAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .Include(a => a.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Admin/AdminAccounts/Create
        public IActionResult Create()
        {
            ViewData["QuyenTruyCap"] = new SelectList(_context.Roles, "Id", "Name");
            return View();
        }

        // POST: Admin/AdminAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Phone,Email,Password,Salt,Active,Name,RoleId,LastLogin,CreateDate")] Account account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var mail = _context.Accounts.FirstOrDefault(x=>x.Email== account.Email);
                    if(mail != null) 
                    {
                        _notyfService.Error("Email đã tồn tại");
                        return View(account);
                    }
                    account.Salt = Utilities.GetRandomKey();
                    account.Password = (account.Password + account.Salt.Trim()).ToMD5();
                    _context.Add(account);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["QuyenTruyCap"] = new SelectList(_context.Roles, "Id", "Name", account.RoleId);
                return View(account);
            }
            catch
            {
                ViewData["QuyenTruyCap"] = new SelectList(_context.Roles, "Id", "Name", account.RoleId);
                return View(account);
            }
        }

        //ChangePassword
        public IActionResult ChangePassword()
        {
            ViewData["QuyenTruyCap"] = new SelectList(_context.Roles, "RoleId", "RoleName");
            return View();
        }


        // GET: Admin/AdminAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            ViewData["QuyenTruyCap"] = new SelectList(_context.Roles, "Id", "Name", account.RoleId);
            return View(account);
        }

        // POST: Admin/AdminAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Phone,Email,Password,Salt,Active,Name,RoleId,LastLogin,CreateDate")] Account account)
        {
            try
            {
                if (id != account.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        Console.WriteLine(account.Password);
                        Console.WriteLine(account.Salt);
                        account.Password = (account.Password.Trim() + account.Salt.Trim()).ToMD5();
                        _context.Update(account);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!AccountExists(account.Id))
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
                ViewData["QuyenTruyCap"] = new SelectList(_context.Roles, "Id", "Name", account.RoleId);
                return View(account);
            }
            catch
            {
                ViewData["QuyenTruyCap"] = new SelectList(_context.Roles, "Id", "Name", account.RoleId);
                return View(account);
            }
        }

        // GET: Admin/AdminAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .Include(a => a.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Admin/AdminAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Accounts == null)
            {
                return Problem("Entity set 'BookStore2Context.Accounts'  is null.");
            }
            var account = await _context.Accounts.FindAsync(id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
            }
            
            await _context.SaveChangesAsync();
            _notyfService.Success("Xóa thành công");
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(int id)
        {
          return (_context.Accounts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
