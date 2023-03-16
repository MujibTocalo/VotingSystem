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
   
   public class BallotsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BallotsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<string>> GetPosition(int id)
        {
            var position = await _context.Positions.FindAsync(id);

            if (position == null)
            {
                return Enumerable.Empty<string>();
            }

            var candidates = await _context.Candidates
                .Where(c => c.position.name == position.name)
                .Select(c => c.name)
                .ToListAsync();

            return candidates;
        }

        public async Task<IEnumerable<string>> GetCandidate(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);

            if (candidate == null)
            {
                return Enumerable.Empty<string>();
            }

            var newCandidate = await _context.Candidates
                .Where(c => c.position.name == candidate.position.name)
                .Select(c => c.name)
                .ToListAsync();

            return newCandidate;
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
        public async Task<IActionResult>Create([Bind("votes,name,position")] Candidates kandidato)
        {
            var namesOfCandidates = new List<string>();

            //ListOfAllPositions
            var positions = await _context.Positions.ToListAsync();

            foreach (var position in positions)
            {
                var Eachcandidates = await GetPosition(position.id);
                namesOfCandidates.AddRange(Eachcandidates);
            }

            var candidates = await _context.Candidates.ToListAsync();

            foreach (var candidate in candidates)
            {
                var Eachcandidates = await GetCandidate(candidate.id);
                namesOfCandidates.AddRange(Eachcandidates);
            }



            // namesOfCandidates now contains the names of all candidates for all positions
            ViewBag.Positions = positions;
            ViewBag.Candidates = candidates;

            var groupedCandidates = candidates
           .Join(positions, c => c.positionId, p => p.id, (c, p) => new { Candidate = c, Position = p })
            .GroupBy(cp => cp.Position, cp => cp.Candidate);

            var candidateNames = groupedCandidates
            .Select(g => new { PositionName = g.Key.name, CandidateNames = g.Select(c => c.name).ToList() })
            .ToList();
            

            ViewBag.GroupedCandidates = groupedCandidates;
            ViewData["organizationId"] = new SelectList(_context.Organizations, "id", "name");


            kandidato.votes++;
            _context.Update(kandidato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            return View();
        }

        // POST: Ballots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      
        /*
        public async Task<IActionResult> Create([Bind("votes,name,position")] Candidates candidate)
        {
            if (ModelState.IsValid)
            {
                candidate.votes++;
                _context.Update(candidate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
          

            return View();
        }
        */
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