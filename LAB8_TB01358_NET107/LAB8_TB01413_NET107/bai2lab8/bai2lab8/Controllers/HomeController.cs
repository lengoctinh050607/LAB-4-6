using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.SessionEmail = HttpContext.Session.GetString("SessionEmail");

        if (string.IsNullOrEmpty(ViewBag.SessionEmail))
        {
            TempData["InfoMessage"] = "Bạn cần đăng nhập để truy cập trang này.";
            return RedirectToAction("Login", "Account");
        }

        ViewBag.Greeting = $"Chào mừng, {ViewBag.SessionEmail}! (Phiên làm việc kéo dài 10 phút)";
        ViewBag.LoggedIn = true;

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}