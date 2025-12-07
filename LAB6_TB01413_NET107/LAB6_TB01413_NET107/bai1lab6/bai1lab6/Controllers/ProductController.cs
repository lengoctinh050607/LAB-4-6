using Microsoft.AspNetCore.Mvc;
using bai1lab6.Models;

namespace bai1lab6.Controllers
{
    public class ProductController : Controller
    {
        
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1500, Stock = 10 },
            new Product { Id = 2, Name = "Chuột", Price = 200, Stock = 40 },
            new Product { Id = 3, Name = "Bàn phím", Price = 350, Stock = 25 }
        };

        
        public IActionResult Index()
        {
            return View(_products);
        }

        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Create(Product p)
        {
            
            p.Id = _products.Max(x => x.Id) + 1;
            _products.Add(p);
            return RedirectToAction("Index");
        }

       
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var prod = _products.FirstOrDefault(p => p.Id == id);
            if (prod == null) return NotFound();
            return View(prod);
        }

        
        [HttpPost]
        public IActionResult Edit(Product updated)
        {
            var p = _products.FirstOrDefault(x => x.Id == updated.Id);
            if (p != null)
            {
                p.Name = updated.Name;
                p.Price = updated.Price;
                p.Stock = updated.Stock;
            }
            return RedirectToAction("Index");
        }

        
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var p = _products.FirstOrDefault(x => x.Id == id);
            if (p != null) _products.Remove(p);
            return RedirectToAction("Index");
        }
    }
}