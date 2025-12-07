using Microsoft.AspNetCore.Mvc;
using bai2lab6.Models;

namespace bai2lab6.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop Gaming", Price = 20000000 },
            new Product { Id = 2, Name = "Chuột không dây", Price = 500000 },
            new Product { Id = 3, Name = "Bàn phím cơ", Price = 1200000 }
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
                products.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var p = products.FirstOrDefault(x => x.Id == id);
            if (p == null) return NotFound();
            return View(p);
        }

        [HttpPost("edit/{id}")]
        public IActionResult Edit(int id, Product model)
        {
            var p = products.FirstOrDefault(x => x.Id == id);
            if (p != null)
            {
                p.Name = model.Name;
                p.Price = model.Price;
                return RedirectToAction("Index"); 
            }
            return View(model);
        }

        // --- XÓA ---
        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var p = products.FirstOrDefault(x => x.Id == id);
            if (p != null)
            {
                products.Remove(p);
            }
            return RedirectToAction("Index");
        }
    }
}