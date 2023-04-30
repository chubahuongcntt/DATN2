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
            Console.WriteLine("NotFound0");
            if (id == null)
            {
                Console.WriteLine("NotFound1");
                return NotFound();
            }
            try
            {
                Console.WriteLine("Found1");
                var taikhoanID = HttpContext.Session.GetString("CustomerId");
                if (string.IsNullOrEmpty(taikhoanID)) return RedirectToAction("Login", "Accounts");
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Id == Convert.ToInt32(taikhoanID));
                if (khachhang == null)
                {
                    Console.WriteLine("1234321");
                    return NotFound();
                }
                var donhang = await _context.Orders
                    .FirstOrDefaultAsync(m => m.Id == id && Convert.ToInt32(taikhoanID) == m.CustomerId);
                if (donhang == null)
                {
                    Console.WriteLine("1234321");
                    return NotFound();
                }
                Console.WriteLine("NotFound2");
                var chitietdonhang = _context.OrderDetails
                    .Include(x => x.ProduceId)
                    .AsNoTracking()
                    .Where(x => x.OrderId == id)
                    .OrderBy(x => x.Id)
                    .ToList();
                Console.WriteLine("NotFound3");
                XemDonHang donHang = new XemDonHang();
                Console.WriteLine("NotFound4");
                donHang.DonHang = donhang;
                Console.WriteLine("NotFound5");
                donHang.ChiTietDonHang = chitietdonhang;
                
                return PartialView("Details", donHang);

            }
            catch
            {
                return NotFound();
            }
        }
    }
}
