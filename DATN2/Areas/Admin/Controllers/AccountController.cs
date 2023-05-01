using Microsoft.AspNetCore.Mvc;
using DATN2.Areas.Admin.Models;
using DATN2.Extension;
using Microsoft.AspNetCore.Authorization;
using AspNetCoreHero.ToastNotification.Abstractions;
using DATN2.Models;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using DATN2.Helpper;

namespace DATN2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly BookStore2Context _context;
        public INotyfService _notyfService { get; }
        public AccountController(BookStore2Context context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


        [AllowAnonymous]
        public IActionResult AdminLogin()
        {
            var taikhoanID = HttpContext.Session.GetString("AccountId");
            if (taikhoanID != null) return RedirectToAction("Index", "Home", new { Area = "Admin" });
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AdminLogin(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Account kh = _context.Accounts
                    .Include(p => p.Role)
                    .SingleOrDefault(p => p.Email.ToLower() == model.UserName.ToLower().Trim());
                    if (kh == null)
                    {
                        return View(model);
                    }
                    string pass = (model.Password.Trim());
                    // + kh.Salt.Trim()
                    if (kh.Password.Trim() != pass)
                    {
                        return View(model);
                    }
                    //đăng nhập thành công

                    //ghi nhận thời gian đăng nhập
                    kh.LastLogin = DateTime.Now;
                    _context.Update(kh);
                    await _context.SaveChangesAsync();
                    var taikhoanID = HttpContext.Session.GetString("AccountId");
                    //identity
                    //luuw seccion Makh
                    HttpContext.Session.SetString("AccountId", kh.Id.ToString());

                    //identity
                    var userClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, kh.Name),
                        new Claim(ClaimTypes.Email, kh.Email),
                        new Claim("AccountId", kh.Id.ToString()),
                        new Claim("RoleId", kh.RoleId.ToString()),
                        new Claim(ClaimTypes.Role, kh.Role.Name)
                    };
                    var grandmaIdentity = new ClaimsIdentity(userClaims, "User Identity");
                    var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                    await HttpContext.SignInAsync(userPrincipal);
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                }
            }
            catch
            {
                return RedirectToAction("AdminLogin", "Account", new { Area = "Admin" });
            }
            return RedirectToAction("AdminLogin", "Account", new { Area = "Admin" });
        }
        //[Route("logout.html", Name = "Logout")]
        public IActionResult AdminLogout()
        {
            try
            {
                HttpContext.SignOutAsync();
                HttpContext.Session.Remove("AccountId");
                return RedirectToAction("AdminLogin", "Account", new { Area = "Admin" });
            }
            catch
            {
                return RedirectToAction("AdminLogin", "Account", new { Area = "Admin" });
            }
        }
    }
}
