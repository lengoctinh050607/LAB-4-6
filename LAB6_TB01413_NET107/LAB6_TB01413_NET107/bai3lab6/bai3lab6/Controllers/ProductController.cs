using Microsoft.AspNetCore.Mvc;
using bai2lab6.Models; 

namespace bai3lab6.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Code = "LAP-0001", Name = "Laptop Gaming", Price = 20000000 },
            new Product { Id = 2, Code = "MOU-1234", Name = "Chuột không dây", Price = 500000 },
            new Product { Id = 3, Code = "KEY-9999", Name = "Bàn phím cơ", Price = 1200000 }
        };

        
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View(products);
        }

        
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                int newId = products.Any() ? products.Max(p => p.Id) + 1 : 1;
                model.Id = newId;
                
                if (string.IsNullOrEmpty(model.Code)) model.Code = "NEW-" + newId.ToString("0000");

                products.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet("edit/{id:int:min(1)}")]
        public IActionResult Edit(int id)
        {
            var p = products.FirstOrDefault(x => x.Id == id);
            if (p == null) return NotFound();
            return View(p);
        }

        [HttpPost("edit/{id:int:min(1)}")]
        public IActionResult Edit(int id, Product model)
        {
            var p = products.FirstOrDefault(x => x.Id == id);
            if (p != null)
            {
                p.Code = model.Code;
                p.Name = model.Name;
                p.Price = model.Price;
                return RedirectToAction("Index");
            }
            return View(model);
        }

       
        [HttpGet("delete/{id:int:min(1)}")]
        public IActionResult Delete(int id)
        {
            var p = products.FirstOrDefault(x => x.Id == id);
            if (p != null)
            {
                products.Remove(p);
            }
            return RedirectToAction("Index");
        }


        [HttpGet(@"details/{productCode:regex([[A-Z]]{{3}}-[[0-9]]{{4}})}")]
        public IActionResult DetailsByCode(string productCode)
        {
            var p = products.FirstOrDefault(x => x.Code == productCode);
            if (p == null)
            {
                return Content($"Mã {productCode} đúng định dạng nhưng không tìm thấy sản phẩm.");
            }
            return View(p);
        }
    }
}