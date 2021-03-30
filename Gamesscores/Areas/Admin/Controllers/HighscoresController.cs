using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gamesscores.Models;

namespace Gamesscores.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HighscoresController : Controller
    {
        private readonly AppDbContext _context;

        public HighscoresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Highscores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Highscores.ToListAsync());
        }

        // GET: Admin/Highscores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var highscore = await _context.Highscores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (highscore == null)
            {
                return NotFound();
            }

            return View(highscore);
        }

        // GET: Admin/Highscores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Highscores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Score,Fullname,Game,Date")] Highscore highscore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(highscore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(highscore);
        }

        // GET: Admin/Highscores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var highscore = await _context.Highscores.FindAsync(id);
            if (highscore == null)
            {
                return NotFound();
            }
            return View(highscore);
        }

        // POST: Admin/Highscores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Score,Fullname,Game,Date")] Highscore highscore)
        {
            if (id != highscore.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(highscore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HighscoreExists(highscore.Id))
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
            return View(highscore);
        }

        // GET: Admin/Highscores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var highscore = await _context.Highscores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (highscore == null)
            {
                return NotFound();
            }

            return View(highscore);
        }

        // POST: Admin/Highscores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var highscore = await _context.Highscores.FindAsync(id);
            _context.Highscores.Remove(highscore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HighscoreExists(int id)
        {
            return _context.Highscores.Any(e => e.Id == id);
        }
    }
}
