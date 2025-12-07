using Microsoft.AspNetCore.Mvc;
using Bai2lab5.Model; 

namespace Bai2lab5.Controllers 
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var majorList = new List<Major>
            {
                new Major { Subname_string = "THIẾT KẾ ĐỒ HOẠ", Image_string = "TKĐH-1.png" },
                new Major { Subname_string = "LẬP TRÌNH MÁY TÍNH - THIẾT BỊ DI ĐỘNG", Image_string = "LTMT-TBDĐ-2.png" },
                new Major { Subname_string = "THIẾT KẾ WEBSITE", Image_string = "ThietKeWebsite.jpg" },
                new Major { Subname_string = "CNTT - ỨNG DỤNG PHẦN MỀM", Image_string = "UDPM.png" }
            };

            return View(majorList);
        }
    }
}