using aksesuarcim.Data;
using aksesuarcim.Dto;
using aksesuarcim.Models;
using eticaret_uygula.Oturum;
using Microsoft.AspNetCore.Mvc;

namespace aksesuarcim.Component
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<CartItem> items = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartViewModel cartwm = new()
            {
                CartItems = items,
                GrandTotal = items.Sum(x => x.Quantity * x.Price)
            };
            return View(cartwm);
        }
    }
}
