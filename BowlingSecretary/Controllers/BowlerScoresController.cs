using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BowlingSecretary.Models;

namespace BowlingSecretary.Controllers
{
    public class BowlerScoresController : Controller
    {
        private readonly BowlingSecretaryContext _context;

        public BowlerScoresController(BowlingSecretaryContext context)
        {
            _context = context;
        }

        // GET: BowlerScores
        public async Task<IActionResult> Index()
        {
            return View(await _context.BowlerScore.ToListAsync());
        }

        // GET: BowlerScores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bowlerScore = await _context.BowlerScore
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bowlerScore == null)
            {
                return NotFound();
            }

            return View(bowlerScore);
        }

        // GET: BowlerScores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BowlerScores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Score,Handicap")] BowlerScore bowlerScore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bowlerScore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bowlerScore);
        }

        // GET: BowlerScores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bowlerScore = await _context.BowlerScore.FindAsync(id);
            if (bowlerScore == null)
            {
                return NotFound();
            }
            return View(bowlerScore);
        }

        // POST: BowlerScores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Score,Handicap")] BowlerScore bowlerScore)
        {
            if (id != bowlerScore.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bowlerScore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BowlerScoreExists(bowlerScore.ID))
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
            return View(bowlerScore);
        }

        // GET: BowlerScores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bowlerScore = await _context.BowlerScore
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bowlerScore == null)
            {
                return NotFound();
            }

            return View(bowlerScore);
        }

        // POST: BowlerScores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bowlerScore = await _context.BowlerScore.FindAsync(id);
            _context.BowlerScore.Remove(bowlerScore);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BowlerScoreExists(int id)
        {
            return _context.BowlerScore.Any(e => e.ID == id);
        }
    }
}
