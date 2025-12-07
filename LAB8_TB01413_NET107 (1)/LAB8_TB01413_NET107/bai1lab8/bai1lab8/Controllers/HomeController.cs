using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        HttpContext.Session.SetString("name", "Phan Viet The");
        HttpContext.Session.SetString("email", "thepv@uit.edu.vn");

        return View();
    }

    public IActionResult About()
    {
        ViewBag.Name = HttpContext.Session.GetString("name");
        ViewBag.Email = HttpContext.Session.GetString("email");

        ViewData["Message"] = "Your about page, please refresh page after one minute";
        ViewData["Title"] = "Demo session login";

        return View();
    }
}
