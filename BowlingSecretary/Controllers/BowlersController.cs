using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BowlingSecretary.Models
{
    public class BowlersController : Controller
    {
        private readonly BowlingSecretaryContext _context;

        public BowlersController(BowlingSecretaryContext context)
        {
            _context = context;
        }

        // GET: Bowlers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bowler.ToListAsync());
        }

        // GET: Bowlers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bowler = await _context.Bowler
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bowler == null)
            {
                return NotFound();
            }

            return View(bowler);
        }

        // GET: Bowlers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bowlers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,CurrentAverage")] Bowler bowler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bowler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bowler);
        }

        // GET: Bowlers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bowler = await _context.Bowler.FindAsync(id);
            if (bowler == null)
            {
                return NotFound();
            }
            return View(bowler);
        }

        // POST: Bowlers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,CurrentAverage")] Bowler bowler)
        {
            if (id != bowler.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bowler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BowlerExists(bowler.ID))
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
            return View(bowler);
        }

        // GET: Bowlers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bowler = await _context.Bowler
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bowler == null)
            {
                return NotFound();
            }

            return View(bowler);
        }

        // POST: Bowlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bowler = await _context.Bowler.FindAsync(id);
            _context.Bowler.Remove(bowler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BowlerExists(int id)
        {
            return _context.Bowler.Any(e => e.ID == id);
        }
    }
}
