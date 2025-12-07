using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using bai2lab8.Models;
using bai2lab8.Data;
using System.Linq;
using System.Threading.Tasks;

public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;

    public AccountController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Register()
    {
        ViewData["Title"] = "Đăng Ký Thành Viên";
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(User user)
    {
        if (_context.Users.Any(u => u.Email == user.Email))
        {
            ModelState.AddModelError("Email", "Email này đã được sử dụng.");
        }
        if (!string.IsNullOrEmpty(user.PhoneNumber) && _context.Users.Any(u => u.PhoneNumber == user.PhoneNumber))
        {
            ModelState.AddModelError("PhoneNumber", "Số điện thoại này đã được sử dụng.");
        }

        if (ModelState.IsValid)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Đăng ký thành công! Hãy đăng nhập.";
            return RedirectToAction("Login");
        }
        return View(user);
    }

    public IActionResult Login()
    {
        ViewData["Title"] = "Đăng Nhập Hệ Thống";
        return View();
    }

    [HttpPost]
    public IActionResult Authenticate(string accountIdentifier, string password)
    {
        User user = null;

        if (accountIdentifier.Contains('@'))
        {
            user = _context.Users.FirstOrDefault(u => u.Email == accountIdentifier && u.Password == password);
        }
        else
        {
            user = _context.Users.FirstOrDefault(u => u.PhoneNumber == accountIdentifier && u.Password == password);
        }

        if (user != null)
        {
            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("SessionEmail", user.Email);

            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = "Tài khoản hoặc mật khẩu không đúng.";
        return View("Login");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        TempData["InfoMessage"] = "Bạn đã đăng xuất.";
        return RedirectToAction("Login");
    }
}