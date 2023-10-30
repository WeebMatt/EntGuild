using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyApplication.Data;
using EntGuild.Models;

namespace EntGuild.Controllers
{
    public class Game_genreController : Controller
    {
        private readonly EntGuildContext _context;

        public Game_genreController(EntGuildContext context)
        {
            _context = context;
        }

        // GET: Game_genre
        public async Task<IActionResult> Index()
        {
              return _context.Game_genre != null ? 
                          View(await _context.Game_genre.ToListAsync()) :
                          Problem("Entity set 'EntGuildContext.Game_genre'  is null.");
        }

        // GET: Game_genre/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Game_genre == null)
            {
                return NotFound();
            }

            var game_genre = await _context.Game_genre
                .FirstOrDefaultAsync(m => m.subGenreID == id);
            if (game_genre == null)
            {
                return NotFound();
            }

            return View(game_genre);
        }

        // GET: Game_genre/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Game_genre/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("subGenreID,Name")] Game_genre game_genre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(game_genre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(game_genre);
        }

        // GET: Game_genre/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Game_genre == null)
            {
                return NotFound();
            }

            var game_genre = await _context.Game_genre.FindAsync(id);
            if (game_genre == null)
            {
                return NotFound();
            }
            return View(game_genre);
        }

        // POST: Game_genre/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("subGenreID,Name")] Game_genre game_genre)
        {
            if (id != game_genre.subGenreID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game_genre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Game_genreExists(game_genre.subGenreID))
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
            return View(game_genre);
        }

        // GET: Game_genre/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Game_genre == null)
            {
                return NotFound();
            }

            var game_genre = await _context.Game_genre
                .FirstOrDefaultAsync(m => m.subGenreID == id);
            if (game_genre == null)
            {
                return NotFound();
            }

            return View(game_genre);
        }

        // POST: Game_genre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Game_genre == null)
            {
                return Problem("Entity set 'EntGuildContext.Game_genre'  is null.");
            }
            var game_genre = await _context.Game_genre.FindAsync(id);
            if (game_genre != null)
            {
                _context.Game_genre.Remove(game_genre);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Game_genreExists(int id)
        {
          return (_context.Game_genre?.Any(e => e.subGenreID == id)).GetValueOrDefault();
        }
    }
}
