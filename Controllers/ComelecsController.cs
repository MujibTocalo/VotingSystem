using System;
using System.Collections.Generic;
using System.Data;
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
    [Authorize(Roles = "Admin")]
    public class ComelecsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ComelecsController(ApplicationDbContext context, 
                                UserManager<IdentityUser> userManager,
                                RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Comelecs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Comelecs.Include(c => c.organization);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Comelecs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comelecs = await _context.Comelecs
                .Include(c => c.organization)
                .FirstOrDefaultAsync(m => m.id == id);
            if (comelecs == null)
            {
                return NotFound();
            }

            return View(comelecs);
        }

        private async Task AssignRoleToUser(IdentityUser user, string role)
        {
            if (await _roleManager.RoleExistsAsync(role))
            {
                await _userManager.AddToRoleAsync(user, role);
            }
        }
        // GET: Comelecs/Create
        public IActionResult Create()
        {
            ViewData["organizationId"] = new SelectList(_context.Organizations, "id", "name");
            return View();
        }
        public string RandomPassword(int size = 0)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append("_");
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        // Generate a random string with a given size and case.
        // If second parameter is true, the return string is lowercase
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        // POST: Comelecs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,user,organizationId, password")] Comelecs comelecs)
        {
            if (ModelState.IsValid)
            {
                string _password = RandomPassword(10);
                var user = new IdentityUser { UserName = comelecs.user, Email = comelecs.user};
                var result = await _userManager.CreateAsync(user, _password);

                Comelecs comelec = new Comelecs();
                comelec.user = comelecs.user;
                comelec.name = comelecs.name;
                comelec.password = _password;
                comelec.organizationId = comelecs.organizationId;

                _context.Add(comelec);
                _context.SaveChanges();

                await AssignRoleToUser(user, "Comelec");
                var claim = new Claim("ComelecsClaim", "True");
                await _userManager.AddClaimAsync(user, new Claim(user.Id, user.Email));
                return RedirectToAction(nameof(Index));
            }
            ViewData["organizationId"] = new SelectList(_context.Organizations, "id", "id", comelecs.organizationId);
            return View(comelecs);
        }

        // GET: Comelecs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comelecs = await _context.Comelecs.FindAsync(id);
            if (comelecs == null)
            {
                return NotFound();
            }
            ViewData["organizationId"] = new SelectList(_context.Organizations, "id", "id", comelecs.organizationId);
            return View(comelecs);
        }

        // POST: Comelecs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,user,organizationId")] Comelecs comelecs)
        {
            if (id != comelecs.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comelecs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComelecsExists(comelecs.id))
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
            ViewData["organizationId"] = new SelectList(_context.Organizations, "id", "id", comelecs.organizationId);
            return View(comelecs);
        }

        // GET: Comelecs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comelecs = await _context.Comelecs
                .Include(c => c.organization)
                .FirstOrDefaultAsync(m => m.id == id);
            if (comelecs == null)
            {
                return NotFound();
            }

            return View(comelecs);
        }

        // POST: Comelecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comelecs = await _context.Comelecs.FindAsync(id);
            _context.Comelecs.Remove(comelecs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComelecsExists(int id)
        {
            return _context.Comelecs.Any(e => e.id == id);
        }
    }
}
