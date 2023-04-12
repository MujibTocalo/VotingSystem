using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore;
using VotingSystem.Data;

namespace VotingSystem.Controllers
{
    [Authorize(Roles = "Admins, Voters")]
    public class BallotsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public BallotsController(ApplicationDbContext context,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager
            )
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
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
        public async Task<IActionResult> Create()
        {
        
            var positions = await _context.Positions.ToListAsync();
            var candidates = await _context.Candidates.ToListAsync();

            List<Ballots> ballots = new List<Ballots>();

            foreach (var item in positions)
            {

                ballots.Add(new Ballots { position = item } );

                ViewData["Positions"] = positions;
                ViewData["Candidates"] = candidates;
            }

           

            return View(ballots);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(List<Ballots> ballots)
        {
            string userName = User.Identity.Name;
            var user = await _userManager.FindByEmailAsync(userName);
            if (ModelState.IsValid)
            {
                var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var voter = _context.Voters.SingleOrDefault(a => a.user == userIdString);

                foreach (var item in ballots)
                {
                    if (voter != null)
                    {
                        Ballots ballot = new Ballots();
                        ballot.candidateId = item.candidateId;
                        ballot.positionId = item.positionId;
                        ballot.organizationId = item.organizationId;
                        ballot.votersId = voter.id;
                        _context.Ballots.Add(ballot);

                        var Count = _context.Candidates.SingleOrDefault(a=> a.id == item.candidateId);
                        Count.votes++;
                        
                    }
                    await _context.SaveChangesAsync();
                }



                // Logout user after saving ballot
                await _signInManager.SignOutAsync();
                await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow.AddMinutes(1000));

                // Redirect user to the login page after logout
                return RedirectToAction(nameof(Index));
            }

            var positions = await _context.Positions.ToListAsync();
            var candidates = await _context.Candidates.ToListAsync();

            ViewData["Positions"] = positions;
            ViewData["Candidates"] = candidates;

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