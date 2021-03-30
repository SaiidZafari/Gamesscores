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
    public class GameListsController : Controller
    {
        private readonly AppDbContext _context;

        public GameListsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/GameLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.gameLists.ToListAsync());
        }

        // GET: Admin/GameLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameList = await _context.gameLists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameList == null)
            {
                return NotFound();
            }

            return View(gameList);
        }

        // GET: Admin/GameLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/GameLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Releaseyear,Gamename,Description,Genre,ImageUrl")] GameList gameList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                
            }
            return View(gameList);
        }

        // GET: Admin/GameLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameList = await _context.gameLists.FindAsync(id);
            if (gameList == null)
            {
                return NotFound();
            }
            return View(gameList);
        }

        // POST: Admin/GameLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Releaseyear,Gamename,Description,Genre,ImageUrl")] GameList gameList)
        {
            if (id != gameList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameListExists(gameList.Id))
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
            return View(gameList);
        }

        // GET: Admin/GameLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameList = await _context.gameLists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gameList == null)
            {
                return NotFound();
            }

            return View(gameList);
        }

        // POST: Admin/GameLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameList = await _context.gameLists.FindAsync(id);
            _context.gameLists.Remove(gameList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameListExists(int id)
        {
            return _context.gameLists.Any(e => e.Id == id);
        }
    }
}
