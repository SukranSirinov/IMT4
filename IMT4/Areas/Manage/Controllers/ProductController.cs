using IMT4.DAL;
using IMT4.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IMT4.Areas.Manage.Controllers
{
 [Area("Manage")]
    public class ProductController : Controller
    {
        public readonly AppDbContext _context;
        public readonly IWebHostEnvironment _env;
        public ProductController(IWebHostEnvironment env,AppDbContext context)
        {
            _env = env;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Product> products = await _context.products.ToListAsync();
            return View(products);
        }
        public IActionResult Update()
        {
            return View(_context.products.FirstOrDefault());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update( Product product,int id)
        {
            Product a = _context.products.Find(id);
            if (product.Image != null)
            {
                if (System.IO.File.Exists(Path.Combine(_env.WebRootPath, "assets", "images", a.ImageUrl)))
                {
                    System.IO.File.Delete(Path.Combine(_env.WebRootPath, "assets", "images", a.ImageUrl));
                }
                string fileName = Guid.NewGuid().ToString() + product.Image.FileName;
                using(FileStream fs=new FileStream(Path.Combine("assets", "images", fileName), FileMode.Create))
                {
                    product.Image.CopyTo(fs);
                }
                a.ImageUrl = fileName;
            }
            a.Name = product.Name;
            a.Title = product.Title;
            a.Price = product.Price;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
