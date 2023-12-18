using aksesuarcim.Data;
using aksesuarcim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eticarethaftasonu.Component
{
    public class TrendingList : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public TrendingList(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            List<Category> categories = _context.categories.ToList();
            ViewBag.Categories = categories;

            var liste = _context.Products.Include(x => x.Category).ToList();
            return View(liste);
        }
    }
}
