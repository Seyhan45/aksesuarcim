using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aksesuarcim.Data;
using aksesuarcim.Models;
using Microsoft.AspNetCore.Http;

namespace aksesuarcim.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.products.Include(p => p.Categories);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.products == null)
            {
                return NotFound();
            }

            var products = await _context.products
                .Include(p => p.Categories)
                .FirstOrDefaultAsync(m => m.product_Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewBag.katelist = new SelectList(_context.categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("product_Id,product_Name,product_Code,product_price,image,detail,discount,CategoryId,union,criterion")] Products products,IFormFile ResimYukle)
        {
            string uzanti = Path.GetExtension(ResimYukle.FileName);
            //resim.jpg .jpg uzantısını burada aldım
            var randomisim = Guid.NewGuid().ToString() + uzanti;
            //yüklenecek resme yeniden isim vermiş oldum
            var yol = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/urunler/",
                randomisim);
            using(var stream = new FileStream(yol, FileMode.Create))
            {
                await ResimYukle.CopyToAsync(stream);
            }
            //bu kodla resim yüklemiş olduk
            products.image = randomisim;

            if (!ModelState.IsValid)
            {
                _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.categories, "CategoryId", "CategoryId", products.CategoryId);
            return View(products);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.products == null)
            {
                return NotFound();
            }
            ViewBag.katelist = new SelectList(_context.categories, "CategoryId", "CategoryName");
            var products = await _context.products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.categories, "CategoryId", "CategoryId", products.CategoryId);
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("product_Id,product_Name,product_Code,product_price,image,detail,discount,CategoryId,union,criterion")] Products products, IFormFile ResimYukle)
        {
            if (id != products.product_Id)
            {
                return NotFound();
            }
            if (ResimYukle!= null)
            {
                string uzanti = Path.GetExtension(ResimYukle.FileName);
                //resim.jpg .jpg uzantısını burada aldım
                var randomisim = Guid.NewGuid().ToString() + uzanti;
                //yüklenecek resme yeniden isim vermiş oldum
                var yol = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/urunler/",
                    randomisim);
                using (var stream = new FileStream(yol, FileMode.Create))
                {
                    await ResimYukle.CopyToAsync(stream);
                }
                //bu kodla resim yüklemiş olduk
                products.image = randomisim;
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.product_Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(products);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.products == null)
            {
                return NotFound();
            }

            var products = await _context.products
                .FirstOrDefaultAsync(m => m.product_Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.products == null)
            {
                return Problem("Entity set 'ApplicationDbContext.products'  is null.");
            }
            var products = await _context.products.FindAsync(id);
            if (products != null)
            {
                _context.products.Remove(products);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
          return (_context.products?.Any(e => e.product_Id == id)).GetValueOrDefault();
        }
    }
}
