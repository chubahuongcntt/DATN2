﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DATN2.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using PagedList.Core;

namespace DATN2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminOrdersController : Controller
    {
        private readonly BookStore2Context _context;

        public INotyfService _notyfService { get; }
        public AdminOrdersController(BookStore2Context context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/Admin
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 20;
            var Orders = _context.Orders.Include(o => o.Customer).Include(o => o.Status)
                .AsNoTracking()
                .OrderBy(x => x.OrderDate);
            PagedList<Order> models = new PagedList<Order>(Orders, pageNumber, pageSize);

            ViewBag.CurrentPage = pageNumber;



            return View(models);
        }

        // GET: Admin/Admin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            var Chitietdonhang = _context.OrderDetails
                .Include(x => x.Produce)
                .AsNoTracking()
                .Where(x => x.OrderId == order.Id)
                .OrderBy(x => x.Id)
                .ToList();
            ViewBag.ChiTiet = Chitietdonhang;
            return View(order);
        }

        public async Task<IActionResult> ChangeStatus(int? id)
        {
            Console.WriteLine("1");
            if (id == null)
            {
                Console.WriteLine("2");
                return NotFound();
            }

            var order = await _context.Orders
                .AsNoTracking()
                .Include(x => x.Customer)
                .FirstOrDefaultAsync(x => x.Id == id);
            Console.WriteLine("3");
            if (order == null)
            {
                Console.WriteLine("4");
                return NotFound();
            }
            Console.WriteLine("5");
            ViewData["Trangthai"] = new SelectList(_context.TransitionStatuses, "Id", "Status", order.StatusId);
            Console.WriteLine("6");
            return View("ChangeStatus", order);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeStatus(int id, [Bind("Id,CustomerId,OrderDate,ShipDate,StatusId,Deleted,Paid,PayDate,PayId,Note,Address,LocationId,District,Ward,TotalMoney")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var donhang = await _context.Orders.AsNoTracking().Include(x => x.Customer).FirstOrDefaultAsync(x => x.Id == id);
                    if (donhang != null)
                    {
                        donhang.StatusId = order.StatusId;
                        if (donhang.Paid == true)
                        {
                            donhang.PayDate = DateTime.Now;
                        }
                        if (donhang.StatusId == 5) donhang.Deleted = true;
                        if (donhang.StatusId == 4) donhang.Paid = true;
                        if (donhang.StatusId == 3) donhang.ShipDate = DateTime.Now;
                    }
                    _context.Update(donhang);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Cập nhật trạng thái đơn hàng thành công");

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            ViewData["Trangthai"] = new SelectList(_context.TransitionStatuses, "Id", "Status", order.StatusId);
            return PartialView("ChangeStatus", order);
        }

        // GET: Admin/Admin/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
            ViewData["StatusId"] = new SelectList(_context.TransitionStatuses, "Id", "Id");
            return View();
        }

        // POST: Admin/Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,OrderDate,ShipDate,StatusId,Deleted,Paid,PayDate,PayId,Note,Address,LocationId,District,Ward,TotalMoney")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", order.CustomerId);
            ViewData["StatusId"] = new SelectList(_context.TransitionStatuses, "Id", "Id", order.StatusId);
            return View(order);
        }

        // GET: Admin/Admin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", order.CustomerId);
            ViewData["StatusId"] = new SelectList(_context.TransitionStatuses, "Id", "Id", order.StatusId);
            return View(order);
        }

        // POST: Admin/Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CustomerId,OrderDate,ShipDate,StatusId,Deleted,Paid,PayDate,PayId,Note,Address,LocationId,District,Ward,TotalMoney")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", order.CustomerId);
            ViewData["StatusId"] = new SelectList(_context.TransitionStatuses, "Id", "Id", order.StatusId);
            return View(order);
        }

        // GET: Admin/Admin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            if (order == null)
            {
                return NotFound();
            }

            var Chitietdonhang = _context.OrderDetails
                .Include(x => x.Produce)
                .AsNoTracking()
                .Where(x => x.OrderId == order.Id)
                .OrderBy(x => x.Id)
                .ToList();
            ViewBag.ChiTiet = Chitietdonhang;

            return View(order);
        }

        // POST: Admin/Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            order.Deleted = true;
            order.StatusId = 7;
            _context.Update(order);
            await _context.SaveChangesAsync();
            _notyfService.Success("Xóa đơn hàng thành công");
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
          return (_context.Orders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}