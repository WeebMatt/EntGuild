using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntGuild.Data;
using EntGuild.Models;

namespace EntGuild.Controllers
{
    public class SubGenresController : Controller
    {
        private readonly EntGuildContext _context;

        public SubGenresController(EntGuildContext context)
        {
            _context = context;
        }

        // GET: SubGenres
        public async Task<IActionResult> Index()
        {
              return _context.SubGenre != null ? 
                          View(await _context.SubGenre.ToListAsync()) :
                          Problem("Entity set 'EntGuildContext.SubGenre'  is null.");
        }

        // GET: SubGenres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SubGenre == null)
            {
                return NotFound();
            }

            var subGenre = await _context.SubGenre
                .FirstOrDefaultAsync(m => m.subGenreID == id);
            if (subGenre == null)
            {
                return NotFound();
            }

            return View(subGenre);
        }

        // GET: SubGenres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SubGenres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("subGenreID,Name")] SubGenre subGenre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subGenre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subGenre);
        }

        // GET: SubGenres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SubGenre == null)
            {
                return NotFound();
            }

            var subGenre = await _context.SubGenre.FindAsync(id);
            if (subGenre == null)
            {
                return NotFound();
            }
            return View(subGenre);
        }

        // POST: SubGenres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("subGenreID,Name")] SubGenre subGenre)
        {
            if (id != subGenre.subGenreID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subGenre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubGenreExists(subGenre.subGenreID))
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
            return View(subGenre);
        }

        // GET: SubGenres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SubGenre == null)
            {
                return NotFound();
            }

            var subGenre = await _context.SubGenre
                .FirstOrDefaultAsync(m => m.subGenreID == id);
            if (subGenre == null)
            {
                return NotFound();
            }

            return View(subGenre);
        }

        // POST: SubGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SubGenre == null)
            {
                return Problem("Entity set 'EntGuildContext.SubGenre'  is null.");
            }
            var subGenre = await _context.SubGenre.FindAsync(id);
            if (subGenre != null)
            {
                _context.SubGenre.Remove(subGenre);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubGenreExists(int id)
        {
          return (_context.SubGenre?.Any(e => e.subGenreID == id)).GetValueOrDefault();
        }
    }
}
