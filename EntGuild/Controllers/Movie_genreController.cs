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
    public class Movie_genreController : Controller
    {
        private readonly EntGuildContext _context;

        public Movie_genreController(EntGuildContext context)
        {
            _context = context;
        }

        // GET: Movie_genre
        public async Task<IActionResult> Index()
        {
              return _context.Movie_genre != null ? 
                          View(await _context.Movie_genre.ToListAsync()) :
                          Problem("Entity set 'EntGuildContext.Movie_genre'  is null.");
        }

        // GET: Movie_genre/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Movie_genre == null)
            {
                return NotFound();
            }

            var movie_genre = await _context.Movie_genre
                .FirstOrDefaultAsync(m => m.subGenreID == id);
            if (movie_genre == null)
            {
                return NotFound();
            }

            return View(movie_genre);
        }

        // GET: Movie_genre/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movie_genre/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("subGenreID,Name")] Movie_genre movie_genre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie_genre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie_genre);
        }

        // GET: Movie_genre/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Movie_genre == null)
            {
                return NotFound();
            }

            var movie_genre = await _context.Movie_genre.FindAsync(id);
            if (movie_genre == null)
            {
                return NotFound();
            }
            return View(movie_genre);
        }

        // POST: Movie_genre/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("subGenreID,Name")] Movie_genre movie_genre)
        {
            if (id != movie_genre.subGenreID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie_genre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Movie_genreExists(movie_genre.subGenreID))
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
            return View(movie_genre);
        }

        // GET: Movie_genre/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Movie_genre == null)
            {
                return NotFound();
            }

            var movie_genre = await _context.Movie_genre
                .FirstOrDefaultAsync(m => m.subGenreID == id);
            if (movie_genre == null)
            {
                return NotFound();
            }

            return View(movie_genre);
        }

        // POST: Movie_genre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Movie_genre == null)
            {
                return Problem("Entity set 'EntGuildContext.Movie_genre'  is null.");
            }
            var movie_genre = await _context.Movie_genre.FindAsync(id);
            if (movie_genre != null)
            {
                _context.Movie_genre.Remove(movie_genre);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Movie_genreExists(int id)
        {
          return (_context.Movie_genre?.Any(e => e.subGenreID == id)).GetValueOrDefault();
        }
    }
}
