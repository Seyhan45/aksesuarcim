using aksesuarcim.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using aksesuarcim.Models;

namespace aksesuarcim.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdminController
        public ActionResult Index()
        {
            var liste=_context.admins.ToList();
            return View(liste);
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            var bul = _context.admins.Find(id);
            return View(bul);
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Admin gelen)
        {
            try
            {
                _context.Add(gelen);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            var bul = _context.admins.Find(id);
            return View(bul);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Admin gelen)
        {
            try
            {
                _context.Update(gelen);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            var bul = _context.admins.Find(id);
            return View(bul);
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Admin gelen)
        {
            try
            {
                _context.Remove(gelen);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
