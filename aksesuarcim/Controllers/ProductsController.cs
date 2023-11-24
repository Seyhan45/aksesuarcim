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
        public IActionResult Index()
        {
            var liste = _context.Products.Include(p=>p.Category).ToList();
            //burada Include methodu ile inner join yaparak category ve products birleştirdik
            return View(liste);

        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var Products = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.product_Id == id);
            if (Products == null)
            {
                return NotFound();
            }

            return View(Products);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewBag.kateliste = new SelectList(_context.categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.F
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("product_Id,product_Name,product_Code,product_price,image,detail,discount,CategoryId,union,criterion")] Products Products, IFormFile ResimYukle)
        {
            if (ResimYukle != null)
            {
                var uzanti = Path.GetExtension(ResimYukle.FileName);
                //bocek.png  .png domates.jpg  .jpg
                string yeniisim = Guid.NewGuid().ToString() + uzanti;

                string yol = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/Urunler/" + yeniisim);
                using (var stream = new FileStream(yol, FileMode.Create))
                {
                   ResimYukle.CopyToAsync(stream);
                }
                Products.image = yeniisim;
            }

            if (ModelState.IsValid==false)
            {
                _context.Add(Products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", Products.CategoryId);
            ViewBag.kateliste = new SelectList(_context.categories, "CategoryId", "CategoryName");
            return View(Products);
        }


        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var Products = await _context.Products.FindAsync(id);
            if (Products == null)
            {
                return NotFound();
            }
            ViewBag.kateliste = new SelectList(_context.categories, "CategoryId", "CategoryName");
            return View(Products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("product_Id,product_Name,product_Code,product_price,image,detail,discount,CategoryId,union,criterion")] Products Products, IFormFile ResimYukle)
        {
            if (ResimYukle != null)
            {
                var uzanti = Path.GetExtension(ResimYukle.FileName);
                //bocek.png  .png domates.jpg  .jpg
                string yeniisim = Guid.NewGuid().ToString() + uzanti;

                string yol = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/Urunler/" + yeniisim);
                using (var stream = new FileStream(yol, FileMode.Create))
                {
                   ResimYukle.CopyToAsync(stream);
                }
                Products.image = yeniisim;
            }

            if (id != Products.product_Id)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid==false)
            {
                try
                {
                    _context.Update(Products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(Products.product_Id))
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
            return View(Products);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var Products = await _context.Products
                .FirstOrDefaultAsync(m => m.product_Id == id);
            if (Products == null)
            {
                return NotFound();
            }

            return View(Products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Products'  is null.");
            }
            var Products = await _context.Products.FindAsync(id);
            if (Products != null)
            {
                _context.Products.Remove(Products);
            }
            //Dosya silme
            string yol = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/Urunler/" + Products.image);
            FileInfo yolFile = new FileInfo(yol);
            if(yolFile.Exists)
            {
                System.IO.File.Delete(yolFile.FullName);
                yolFile.Delete();
            }
            //Dosya Silme
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool ProductsExists(int id)
        {
          return (_context.Products?.Any(e => e.product_Id == id)).GetValueOrDefault();
        }
    }
}
