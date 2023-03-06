using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VotingSystem.Data;

namespace VotingSystem.Controllers
{
    [Authorize (Roles = "Voters")]
    
    public class BallotsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BallotsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ballots
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Ballots.Include(b => b.voters);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ballots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ballots = await _context.Ballots
                .Include(b => b.voters)
                .FirstOrDefaultAsync(m => m.id == id);
            if (ballots == null)
            {
                return NotFound();
            }

            return View(ballots);
        }

        // GET: Ballots/Create
        public IActionResult Create()
        {
            ViewData["votersId"] = new SelectList(_context.Voters, "id", "name");
            ViewData["positionId"] = new SelectList(_context.Positions, "id", "name");
            ViewData["candidateId"] = new SelectList(_context.Candidates, "id", "name");
            ViewData["organizationId"] = new SelectList(_context.Organizations, "id", "name");
            return View();
        }

        // POST: Ballots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,votersId,candidateId,positionId,organizationId")] Ballots ballots)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ballots);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["votersId"] = new SelectList(_context.Voters, "id", "id", ballots.votersId);
            ViewData["candidatesId"] = new SelectList(_context.Candidates, "id", "id", ballots.candidateId);
            ViewData["positonId"] = new SelectList(_context.Positions, "id", "id", ballots.positionId);
            ViewData["organizationId"] = new SelectList(_context.Organizations, "id", "id", ballots.organizationId);
            return View(ballots);
        }

        // GET: Ballots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ballots = await _context.Ballots.FindAsync(id);
            if (ballots == null)
            {
                return NotFound();
            }
            ViewData["votersId"] = new SelectList(_context.Voters, "id", "id", ballots.votersId);
            ViewData["candidatesId"] = new SelectList(_context.Candidates, "id", "id", ballots.candidateId);
            ViewData["positonId"] = new SelectList(_context.Positions, "id", "id", ballots.positionId);
            ViewData["organizationId"] = new SelectList(_context.Organizations, "id", "id", ballots.organizationId);

            return View(ballots);
        }

        // POST: Ballots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,votersId,candidateId,positionId,organizationId")] Ballots ballots)
        {
            if (id != ballots.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ballots);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BallotsExists(ballots.id))
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
            ViewData["votersId"] = new SelectList(_context.Voters, "id", "id", ballots.votersId);
            ViewData["candidatesId"] = new SelectList(_context.Candidates, "id", "id", ballots.candidateId);
            ViewData["positonId"] = new SelectList(_context.Positions, "id", "id", ballots.positionId);
            ViewData["organizationId"] = new SelectList(_context.Organizations, "id", "id", ballots.organizationId);
            return View(ballots);
        }

        // GET: Ballots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ballots = await _context.Ballots
                .Include(b => b.voters)
                .FirstOrDefaultAsync(m => m.id == id);
            if (ballots == null)
            {
                return NotFound();
            }

            return View(ballots);
        }

        // POST: Ballots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ballots = await _context.Ballots.FindAsync(id);
            _context.Ballots.Remove(ballots);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BallotsExists(int id)
        {
            return _context.Ballots.Any(e => e.id == id);
        }
    }
}
