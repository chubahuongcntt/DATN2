using AspNetCoreHero.ToastNotification.Abstractions;
using DATN2.Models;
using Microsoft.AspNetCore.Mvc;
using DATN2.ModelViews;
using DATN2.Extension;

namespace DATN2.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly BookStore2Context _context;
        public INotyfService _notyfService { get; }
        public ShoppingCartController(BookStore2Context context, INotyfService notyfService)
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
        [HttpPost]
        [Route("api/cart/add")]
        public IActionResult AddToCart(int Id, int? amount)
        {
            List<CartItem> cart = GioHang;

            try
            {
                //Them san pham vao gio hang
                CartItem item = cart.SingleOrDefault(p => p.produce.Id == Id);
                if (item != null) // da co => cap nhat so luong
                {
                    item.amount = item.amount + amount.Value;
                    //luu lai session
                    Produce hh = _context.Produces.SingleOrDefault(p => p.Id == Id);
                    if (item.amount > hh.UnitslnStock)
                    {
                        _notyfService.Error("Thêm sản phẩm không thành công");
                        return Json(new { success = false });
                    }    
                    HttpContext.Session.Set<List<CartItem>>("GioHang", cart);
                }
                else
                {
                    Produce hh = _context.Produces.SingleOrDefault(p => p.Id == Id);
                    item = new CartItem
                    {
                        amount = amount.HasValue ? amount.Value : 1,
                        produce = hh
                    };
                    if (item.amount > hh.UnitslnStock)
                    {
                        _notyfService.Error("Thêm sản phẩm không thành công");
                        return Json(new { success = false });
                    }
                    cart.Add(item);//Them vao gio
                }

                //Luu lai Session
                HttpContext.Session.Set<List<CartItem>>("GioHang", cart);
                _notyfService.Success("Thêm sản phẩm thành công");
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }
        [HttpPost]
        [Route("api/cart/update")]
        public IActionResult UpdateCart(int Id, int? amount)
        {
            //Lay gio hang ra de xu ly
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            try
            {
                if (cart != null)
                {
                    CartItem item = cart.SingleOrDefault(p => p.produce.Id == Id);
                    if (item != null && amount.HasValue) // da co -> cap nhat so luong
                    {
                        item.amount = amount.Value;
                    }
                    //Luu lai session
                    HttpContext.Session.Set<List<CartItem>>("GioHang", cart);
                }
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }
        [HttpPost]
        [Route("api/cart/remove")]
        public ActionResult Remove(int Id)
        {

            try
            {
                List<CartItem> gioHang = GioHang;
                CartItem item = gioHang.SingleOrDefault(p => p.produce.Id == Id);
                if (item != null)
                {
                    gioHang.Remove(item);
                }
                //luu lai session
                HttpContext.Session.Set<List<CartItem>>("GioHang", gioHang);
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }
        [Route("cart.html", Name = "Cart")]
        public IActionResult Index()
        {
            return View(GioHang);
        }
    }
}
