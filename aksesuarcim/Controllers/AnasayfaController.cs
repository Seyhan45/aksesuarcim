using aksesuarcim.Data;
using aksesuarcim.Models;
using Microsoft.AspNetCore.Mvc;

namespace aksesuarcim.Controllers
{
    public class AnasayfaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnasayfaController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Urunler()
        {
            List<Category> kategoriler = _context.categories.ToList();
            ViewBag.kategori = kategoriler;
            ViewBag.kategori = _context.categories.ToList();
            var urunler = _context.products.ToList();
            return View(urunler);
        }
        [HttpGet]
        public IActionResult UrunDetay(int id)
        {
            var urun = _context.products.Find(id);
            return View(urun);
        }

        public IActionResult RelatedProduct(int id)
        {
            var urunler = _context.products.ToList();
            return View(urunler);
        }
    }
}
