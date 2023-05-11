using AspNetCoreHero.ToastNotification.Abstractions;
using DATN2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DATN2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class StatisticalController : Controller
    {
        private readonly BookStore2Context _context;
        public StatisticalController(BookStore2Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetStatistical(string formDate, string toDate)
        {
            var query = from o in _context.Orders
                        join od in _context.OrderDetails
                        on o.Id equals od.OrderId
                        join p in _context.Produces
                        on od.ProduceId equals p.Id
                        where(o.StatusId==4)
                        select new
                        {
                            CreateDate = o.OrderDate,
                            Quantity = od.Quantity,
                            Price = od.Price,
                        };
            if(!string.IsNullOrEmpty(formDate))
            {
                DateTime startDate = DateTime.ParseExact(formDate, "dd/MM/yyyy", null);
                query = query.Where(x => x.CreateDate >= startDate);
            }
            if (!string.IsNullOrEmpty(toDate))
            {
                DateTime endDate = DateTime.ParseExact(toDate, "dd/MM/yyyy", null);
                query = query.Where(x => x.CreateDate <= endDate);
            }
            var result = query.GroupBy(x => x.CreateDate).Select(x => new
            {
                Date = x.Key.Value,
                TotalBuy = x.Sum(y => y.Quantity * y.Price),
            }).Select(x => new
            {
                Date = x.Date,
                DoanhThu = x.TotalBuy
            });
            return Json(new {Data = result});
        }
    }
}
