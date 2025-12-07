using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        string username = Request.Cookies["RememberUser"];

        if (!string.IsNullOrEmpty(username))
        {
            ViewBag.Greeting = $"Xin chào, {username}!";
            ViewBag.LoggedIn = true;
        }
        else
        {
            ViewBag.Greeting = "Chào mừng bạn!";
            ViewBag.LoggedIn = false;
        }

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}