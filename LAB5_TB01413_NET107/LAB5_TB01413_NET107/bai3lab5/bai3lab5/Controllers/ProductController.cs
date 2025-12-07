using Microsoft.AspNetCore.Mvc;
using bai3lab5.Models;
using System.Collections.Generic;

namespace bai3lab5.Controllers
{
    public class ProductController : Controller
    {
        
        private static List<Product> _products = new List<Product>
        {
            new Product { Name = "Men Shoes", Price = 99.99f, Quantity = 100 },
            new Product { Name = "Women Shoes", Price = 199.99f, Quantity = 200 },
            new Product { Name = "Children Games", Price = 299.99f, Quantity = 300 },
            new Product { Name = "Coats", Price = 399.99f, Quantity = 400 }
        };

        
        public IActionResult Index()
        {
            return View(_products); 
        }

        
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Product());
        }

        
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                
                _products.Add(product);
            }

            
            return RedirectToAction("Index");
        }
    }
}