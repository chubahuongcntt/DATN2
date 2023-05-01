using AspNetCoreHero.ToastNotification.Abstractions;
using DATN2.Extension;
using DATN2.Helpper;
using DATN2.Models;
using DATN2.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DATN2.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly BookStore2Context _context;
        public INotyfService _notyfService { get; }
        public CheckoutController(BookStore2Context context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        public List<CartItem> GioHang
        {
            get
            {
                var gh = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if (gh == default(List<CartItem>))
                {
                    gh = new List<CartItem>();
                }
                return gh;
            }
        }
        [Route("checkout.html", Name = "Checkout")]
        public IActionResult Index(string returnUrl = null)
        {
            //Lay gio hang ra de xu ly
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            var taikhoanID = HttpContext.Session.GetString("CustomerId");
            MuaHangVM model = new MuaHangVM();
            if (taikhoanID != null)
            {
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Id == Convert.ToInt32(taikhoanID));
                model.CustomerId = khachhang.Id;
                model.FullName = khachhang.Name;
                model.Email = khachhang.Email;
                model.Phone = khachhang.Phone;
                model.Address = khachhang.Address;
            }
            ViewData["lsTinhThanh"] = new SelectList(_context.Locations.Where(x => x.Level == 1).OrderBy(x => x.Type).ToList(), "Location", "Name");
            ViewBag.GioHang = cart;
            return View(model);
        }

        [HttpPost]
        [Route("checkout.html", Name = "Checkout")]
        public IActionResult Index(MuaHangVM muaHang)
        {
            //Lay ra gio hang de xu ly
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            var taikhoanID = HttpContext.Session.GetString("CustomerId");
            MuaHangVM model = new MuaHangVM();
            Console.WriteLine("1");
            if (taikhoanID != null)
            {
                Console.WriteLine("2");
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Id == Convert.ToInt32(taikhoanID));
                model.CustomerId = khachhang.Id;
                model.FullName = khachhang.Name;
                model.Email = khachhang.Email;
                model.Phone = khachhang.Phone;
                model.Address = khachhang.Address;

                khachhang.LocationId = muaHang.TinhThanh;
                khachhang.District = muaHang.QuanHuyen;
                khachhang.Ward = muaHang.PhuongXa;
                khachhang.Address = muaHang.Address;
                _context.Update(khachhang);
                _context.SaveChanges();
            }
            try
            {
                Console.WriteLine("3");
                if (ModelState.IsValid)
                {
                    Console.WriteLine("4");
                    //Khoi tao don hang
                    Order donhang = new Order();
                    donhang.CustomerId = model.CustomerId;
                    donhang.Address = model.Address;
                    donhang.LocationId = model.TinhThanh;
                    donhang.District = model.QuanHuyen;
                    donhang.Ward = model.PhuongXa;

                    donhang.OrderDate = DateTime.Now;
                    donhang.StatusId = 1;//Don hang moi
                    donhang.Deleted = false;
                    donhang.Paid = false;
                    donhang.Note = Utilities.StripHTML(model.Note);
                    donhang.TotalMoney = Convert.ToInt32(cart.Sum(x => x.TotalMoney));
                    _context.Add(donhang);
                    _context.SaveChanges();
                    //tao danh sach don hang

                    foreach (var item in cart)
                    {
                        foreach (var sanpham in _context.Produces)
                        {
                            if (item.produce.Id == sanpham.Id)
                            {
                                sanpham.UnitslnStock -= item.amount;
                                _context.Produces.Update(sanpham);
                            }
                        }
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.OrderId = donhang.Id;
                        orderDetail.ProduceId = item.produce.Id;
                        orderDetail.Amount = item.amount;
                        orderDetail.Quantity = item.amount;
                        orderDetail.Price = item.produce.Discount;
                        orderDetail.TotalMoney = (int?)item.TotalMoney;
                        orderDetail.CreateDate = DateTime.Now;
                        _context.Add(orderDetail);
                    }
                    _context.SaveChanges();
                    //clear gio hang
                    HttpContext.Session.Remove("GioHang");
                    //Xuat thong bao
                    _notyfService.Success("Đơn hàng đặt thành công");
                    //cap nhat thong tin khach hang
                    return RedirectToAction("Success");


                }
            }
            catch
            {
                Console.WriteLine("5");
                ViewData["lsTinhThanh"] = new SelectList(_context.Locations.Where(x => x.Level == 1).OrderBy(x => x.Type).ToList(), "Location", "Name");
                ViewBag.GioHang = cart;
                return View(model);
            }
            Console.WriteLine("6");
            ViewData["lsTinhThanh"] = new SelectList(_context.Locations.Where(x => x.Level == 1).OrderBy(x => x.Type).ToList(), "Location", "Name");
            ViewBag.GioHang = cart;
            return View(model);
        }
        [Route("dat-hang-thanh-cong.html", Name = "Success")]
        public IActionResult Success()
        {
            try
            {
                var taikhoanID = HttpContext.Session.GetString("CustomerId");
                if (string.IsNullOrEmpty(taikhoanID))
                {
                    return RedirectToAction("Login", "Accounts", new { returnUrl = "/dat-hang-thanh-cong.html" });
                }
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.Id == Convert.ToInt32(taikhoanID));
                var donhang = _context.Orders
                    .Where(x => x.CustomerId == Convert.ToInt32(taikhoanID))
                    .OrderByDescending(x => x.OrderDate)
                    .FirstOrDefault();
                MuaHangSuccessVM successVM = new MuaHangSuccessVM();
                successVM.FullName = khachhang.Name;
                successVM.DonHangID = donhang.Id;
                successVM.Phone = khachhang.Phone;
                successVM.Address = khachhang.Address;
                successVM.PhuongXa = GetNameLocation(donhang.Ward.Value);
                successVM.TinhThanh = GetNameLocation(donhang.District.Value);
                return View(successVM);
            }
            catch
            {
                return View();
            }
        }
        public string GetNameLocation(int idlocation)
        {
            try
            {
                var location = _context.Locations.AsNoTracking().SingleOrDefault(x => x.Id == idlocation);
                if (location != null)
                {
                    return location.NameWithType;
                }
            }
            catch
            {
                return string.Empty;
            }
            return string.Empty;
        }
    }
}
