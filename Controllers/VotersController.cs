using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VotingSystem.Data;

namespace VotingSystem.Controllers
{
    [Authorize(Roles = "Admin, Comelec")]
    public class VotersController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public VotersController (ApplicationDbContext context,
                                UserManager<IdentityUser> userManager,
                                RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        private async Task AssignRoleToUser(IdentityUser user, string role)
        {
            if (await _roleManager.RoleExistsAsync(role))
            {
                await _userManager.AddToRoleAsync(user, role);
            }
        }

        // GET: Voters
        public async Task<IActionResult> Index()
        {
            string userName = User.Identity.Name;
            var user = await _userManager.FindByEmailAsync(userName);

            return View(await _context.Voters.ToListAsync());

        }

        // GET: Voters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voters = await _context.Voters
                .FirstOrDefaultAsync(m => m.id == id);
            if (voters == null)
            {
                return NotFound();
            }

            return View(voters);
        }

        // GET: Voters/Create
        public string RandomPassword(int size = 0)
        {
            return RandomString(9);
        }

        // Generate a random string of a given size with all upper case characters.
        public string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }

        public IActionResult Create()
        {
            ViewData["organizationId"] = new SelectList(_context.Organizations, "id", "name", "user");
            return View();
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,organizationId, password, user, yearlevel, course, username")] Voters voters)
        {
            if (ModelState.IsValid)
            {

                string _password = RandomPassword(9);
                var user = new IdentityUser { UserName = voters.user, Email = voters.user };
                var result = await _userManager.CreateAsync(user, _password);

                Voters voter = new Voters();
                voter.user = user.Id;   
                voter.name = voters.name;
                voter.password = _password;
                voter.organizationId = voters.organizationId;
                voter.username = user.UserName;
                voter.yearlevel = voters.yearlevel;
                voter.course = voters.course;


                _context.Add(voter);
                _context.SaveChanges();

                await AssignRoleToUser(user, "Voter");
                var claim = new Claim("VotersClaim", "True");
                await _userManager.AddClaimAsync(user, new Claim(user.Id, user.Email));
                return RedirectToAction(nameof(Create));
            }
            ViewData["organizationId"] = new SelectList(_context.Organizations, "id", "name");
            return View(voters);

        }

        // GET: Voters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voters = await _context.Voters.FindAsync(id);
            if (voters == null)
            {
                return NotFound();
            }
            return View(voters);
        }

        // POST: Voters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,organizationId")] Voters voters)
        {
            if (id != voters.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voters);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VotersExists(voters.id))
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
            return View(voters);
        }

        // GET: Voters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voters = await _context.Voters
                .FirstOrDefaultAsync(m => m.id == id);
            if (voters == null)
            {
                return NotFound();
            }

            return View(voters);
        }

        // POST: Voters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var voters = await _context.Voters.FindAsync(id);
            _context.Voters.Remove(voters);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VotersExists(int id)
        {
            return _context.Voters.Any(e => e.id == id);
        }
    }
}
