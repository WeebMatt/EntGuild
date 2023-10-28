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
    public class Book_genreController : Controller
    {
        private readonly EntGuildContext _context;

        public Book_genreController(EntGuildContext context)
        {
            _context = context;
        }

        // GET: Book_genre
        public async Task<IActionResult> Index()
        {
              return _context.Book_genre != null ? 
                          View(await _context.Book_genre.ToListAsync()) :
                          Problem("Entity set 'EntGuildContext.Book_genre'  is null.");
        }

        // GET: Book_genre/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Book_genre == null)
            {
                return NotFound();
            }

            var book_genre = await _context.Book_genre
                .FirstOrDefaultAsync(m => m.subGenreID == id);
            if (book_genre == null)
            {
                return NotFound();
            }

            return View(book_genre);
        }

        // GET: Book_genre/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Book_genre/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("subGenreID,Name")] Book_genre book_genre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book_genre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book_genre);
        }

        // GET: Book_genre/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Book_genre == null)
            {
                return NotFound();
            }

            var book_genre = await _context.Book_genre.FindAsync(id);
            if (book_genre == null)
            {
                return NotFound();
            }
            return View(book_genre);
        }

        // POST: Book_genre/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("subGenreID,Name")] Book_genre book_genre)
        {
            if (id != book_genre.subGenreID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book_genre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Book_genreExists(book_genre.subGenreID))
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
            return View(book_genre);
        }

        // GET: Book_genre/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Book_genre == null)
            {
                return NotFound();
            }

            var book_genre = await _context.Book_genre
                .FirstOrDefaultAsync(m => m.subGenreID == id);
            if (book_genre == null)
            {
                return NotFound();
            }

            return View(book_genre);
        }

        // POST: Book_genre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Book_genre == null)
            {
                return Problem("Entity set 'EntGuildContext.Book_genre'  is null.");
            }
            var book_genre = await _context.Book_genre.FindAsync(id);
            if (book_genre != null)
            {
                _context.Book_genre.Remove(book_genre);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Book_genreExists(int id)
        {
          return (_context.Book_genre?.Any(e => e.subGenreID == id)).GetValueOrDefault();
        }
    }
}
