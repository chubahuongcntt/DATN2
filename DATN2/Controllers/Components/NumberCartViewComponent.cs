using DATN2.Extension;
using DATN2.ModelViews;
using Microsoft.AspNetCore.Mvc;

namespace DATN2.Controllers.Components
{
    public class NumberCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            return View(cart);
        }
    }
}
