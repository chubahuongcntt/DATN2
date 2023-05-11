using AspNetCoreHero.ToastNotification.Abstractions;
using DATN2.Models;
using DATN2.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DATN2.Controllers
{
    public class DonHangController : Controller
    {
        private readonly BookStore2Context _context;
        public INotyfService _notyfService { get; }
        public DonHangController(BookStore2Context context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        [HttpPost]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var taikhoanID = HttpContext.Session.GetString("CustomerId");
                if (string.IsNullOrEmpty(taikhoanID)) return RedirectToAction("Login", "Accounts");
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Id == Convert.ToInt32(taikhoanID));
                if (khachhang == null)
                {
                    return NotFound();
                }
                var donhang = await _context.Orders
                    .FirstOrDefaultAsync(m => m.Id == id && Convert.ToInt32(taikhoanID) == m.CustomerId);
                if (donhang == null)
                {
                    return NotFound();
                }
                var chitietdonhang = _context.OrderDetails
                    .Include(x => x.Produce)
                    .AsNoTracking()
                    .Where(x => x.OrderId == id)
                    .OrderBy(x => x.Id)
                    .ToList();
                XemDonHang donHang = new XemDonHang();
                donHang.DonHang = donhang;
                donHang.ChiTietDonHang = chitietdonhang;                
                return PartialView("Details", donHang);

            }
            catch
            {
                return NotFound();
            }
        }
        public async Task<IActionResult> HuyDonHang(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var taikhoanID = HttpContext.Session.GetString("CustomerId");
                if (string.IsNullOrEmpty(taikhoanID)) return RedirectToAction("Login", "Accounts");
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Id == Convert.ToInt32(taikhoanID));
                if (khachhang == null)
                {
                    return NotFound();
                }
                var donhang = await _context.Orders
                    .FirstOrDefaultAsync(m => m.Id == id && Convert.ToInt32(taikhoanID) == m.CustomerId);
                if (donhang == null)
                {
                    return NotFound();
                }
                donhang.StatusId = 5;
                _context.Update(donhang);
                await _context.SaveChangesAsync();
                _notyfService.Success("Đã hủy đơn hàng");
                return RedirectToAction("Dashboard", "Accounts");

            }
            catch
            {
                return NotFound();
            }
        }
        public async Task<IActionResult> DatLaiHang(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var taikhoanID = HttpContext.Session.GetString("CustomerId");
                if (string.IsNullOrEmpty(taikhoanID)) return RedirectToAction("Login", "Accounts");
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Id == Convert.ToInt32(taikhoanID));
                if (khachhang == null)
                {
                    return NotFound();
                }
                var donhang = await _context.Orders
                    .FirstOrDefaultAsync(m => m.Id == id && Convert.ToInt32(taikhoanID) == m.CustomerId);
                if (donhang == null)
                {
                    return NotFound();
                }
                donhang.StatusId = 1;
                donhang.OrderDate= DateTime.Now;
                _context.Update(donhang);
                await _context.SaveChangesAsync();
                _notyfService.Success("Đặt hàng thành công");
                return RedirectToAction("Dashboard", "Accounts");

            }
            catch
            {
                return NotFound();
            }
        }
    }
}
