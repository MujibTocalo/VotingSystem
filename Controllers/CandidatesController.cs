using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore;
using VotingSystem.Data;

namespace VotingSystem.Controllers
{
    [Authorize(Roles = "Admins, Comelec")]


    public class CandidatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CandidatesController(ApplicationDbContext context)
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

        // GET: Candidates
        public async Task<IActionResult> Index()
        {

            //ListOfAllCandidates
            var namesOfCandidates = new List<string>();

            //ListOfAllPositions
            var positions = await _context.Positions.ToListAsync();

            foreach (var position in positions)
            {
                var Eachcandidates = await GetPosition(position.id);
                namesOfCandidates.AddRange(Eachcandidates);
            }

            var candidates = await _context.Candidates.Include(c=>c.organization).ToListAsync();

            foreach (var candidate in candidates)
            {
                var Eachcandidates = await GetCandidate(candidate.id);
                namesOfCandidates.AddRange(Eachcandidates);
            }



            // namesOfCandidates now contains the names of all candidates for all positions
            ViewBag.Positions = positions;
            ViewBag.Candidates = candidates;

            return View();
        }

        // GET: Candidates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidates = await _context.Candidates
                .FirstOrDefaultAsync(m => m.id == id);
            if (candidates == null)
            {
                return NotFound();
            }

            return View(candidates);
        }

        // GET: Candidates/Create
        public IActionResult Create()
        {
            ViewData["positionId"] = new SelectList(_context.Positions, "id", "name");
            ViewData["organizationId"] = new SelectList(_context.Organizations, "id", "name");
            return View();
        }

        // POST: Candidates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,positionId,organizationId")] Candidates candidates)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidates);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["positionId"] = new SelectList(_context.Positions, "id", "name");
            ViewData["organizationId"] = new SelectList(_context.Organizations, "id", "name");
            return View(candidates);
        }

        // GET: Candidates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidates = await _context.Candidates.FindAsync(id);
            if (candidates == null)
            {
                return NotFound();
            }
            ViewData["positionId"] = new SelectList(_context.Positions, "id", "id", candidates.positionId);
            ViewData["organizationId"] = new SelectList(_context.Organizations, "id", "id", candidates.organizationId);
            return View(candidates);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,positionId,organizationId")] Candidates candidates)
        {
            if (id != candidates.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidates);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatesExists(candidates.id))
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
            ViewData["positionId"] = new SelectList(_context.Positions, "id", "id", candidates.positionId);
            ViewData["organizationId"] = new SelectList(_context.Organizations, "id", "id", candidates.organizationId);
            return View(candidates);
        }

        // GET: Candidates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidates = await _context.Candidates
                .FirstOrDefaultAsync(m => m.id == id);
            if (candidates == null)
            {
                return NotFound();
            }

            return View(candidates);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidates = await _context.Candidates.FindAsync(id);
            _context.Candidates.Remove(candidates);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidatesExists(int id)
        {
            return _context.Candidates.Any(e => e.id == id);
        }
    }
}
