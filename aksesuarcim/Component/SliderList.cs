using aksesuarcim.Data;
using Microsoft.AspNetCore.Mvc;


namespace aksesuarcim.Component
{
    public class SliderList : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public SliderList(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var result = _context.sliders.ToList();
            return View(result);

        }
    }
}
