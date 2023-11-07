using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aksesuarcim.Data;
using aksesuarcim.Models;

namespace eticaret_uygula.Controllers
{
	public class slidersController : Controller
	{
		private readonly ApplicationDbContext _context;

		public slidersController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: sliders
		public async Task<IActionResult> Index()
		{
			return _context.sliders != null ?
						View(await _context.sliders.ToListAsync()) :
						Problem("Entity set 'ApplicationDbContext.Slider'  is null.");
		}

		// GET: sliders/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.sliders == null)
			{
				return NotFound();
			}

			var slider = await _context.sliders
				.FirstOrDefaultAsync(m => m.SliderId == id);
			if (slider == null)
			{
				return NotFound();
			}

			return View(slider);
		}

		// GET: sliders/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: sliders/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("SliderId,SliderName,Heeader1,Heeader2,Context,SliderImage")] Slider slider)
		{
			if (ModelState.IsValid)
			{
				_context.Add(slider);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(slider);
		}

		// GET: sliders/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.sliders == null)
			{
				return NotFound();
			}

			var slider = await _context.sliders.FindAsync(id);
			if (slider == null)
			{
				return NotFound();
			}
			return View(slider);
		}

		// POST: sliders/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("SliderId,SliderName,Heeader1,Heeader2,Context,SliderImage")] Slider slider)
		{
			if (id != slider.SliderId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(slider);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!sliderExists(slider.SliderId))
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
			return View(slider);
		}

		// GET: sliders/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.sliders == null)
			{
				return NotFound();
			}

			var slider = await _context.sliders
				.FirstOrDefaultAsync(m => m.SliderId == id);
			if (slider == null)
			{
				return NotFound();
			}

			return View(slider);
		}

		// POST: sliders/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.sliders == null)
			{
				return Problem("Entity set 'ApplicationDbContext.Slider'  is null.");
			}
			var slider = await _context.sliders.FindAsync(id);
			if (slider != null)
			{
				_context.sliders.Remove(slider);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool sliderExists(int id)
		{
			return (_context.sliders?.Any(e => e.SliderId == id)).GetValueOrDefault();
		}
	}
}