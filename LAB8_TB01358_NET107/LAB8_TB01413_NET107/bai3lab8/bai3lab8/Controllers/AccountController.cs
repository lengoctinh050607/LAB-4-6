using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using bai3lab8.Models;
using bai3lab8.Data;
using System.Linq;
using System;

public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;

    public AccountController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Login()
    {
        ViewData["Title"] = "Đăng Nhập Hệ Thống";
        return View();
    }

    [HttpPost]
    public IActionResult Authenticate(string username, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

        if (user != null)
        {
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(7),
                IsEssential = true
            };
            Response.Cookies.Append("RememberUser", user.Username, options);

            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = "Tên người dùng hoặc mật khẩu không đúng.";
        return View("Login");
    }

    public IActionResult Logout()
    {
        Response.Cookies.Delete("RememberUser");
        TempData["InfoMessage"] = "Bạn đã đăng xuất.";
        return RedirectToAction("Login");
    }
}