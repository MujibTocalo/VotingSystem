using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VotingSystem.Data;
using VotingSystem.Models;
using static Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal.ExternalLoginModel;

namespace VotingSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ComelecsController : Controller
    {
        UserManager<IdentityUser> userManager;
        RoleManager<IdentityRole> roleManager;

        public InputModel Input { get; set; }
        public class InputModel
        {
            [Required]
            [Display(Name = "Name")]
            public string Name { get; set; }
        };



            private readonly ApplicationDbContext _context;

        private async Task AssignRoleToUser(IdentityUser user, string role)
        {
            if (await roleManager.RoleExistsAsync(role))
            {
                await userManager.AddToRoleAsync(user, role);
            }
        }

        public ComelecsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Comelecs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Comelec.ToListAsync());
        }

        // GET: Comelecs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comelec = await _context.Comelec
                .FirstOrDefaultAsync(m => m.id == id);
            if (comelec == null)
            {
                return NotFound();
            }

            return View(comelec);
        }

        // GET: Comelecs/Create
        public IActionResult Create()

        {
            return View();
        }

        // POST: Comelecs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name")] Comelec comelec)
        {
           
            if (ModelState.IsValid)
            {

                _context.Add(comelec);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return View(comelec);
        }


        // GET: Comelecs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comelec = await _context.Comelec.FindAsync(id);
            if (comelec == null)
            {
                return NotFound();
            }
            return View(comelec);
        }

        // POST: Comelecs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name")] Comelec comelec)
        {
            if (id != comelec.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comelec);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComelecExists(comelec.id))
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
            return View(comelec);
        }

        // GET: Comelecs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comelec = await _context.Comelec
                .FirstOrDefaultAsync(m => m.id == id);
            if (comelec == null)
            {
                return NotFound();
            }

            return View(comelec);
        }

        // POST: Comelecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comelec = await _context.Comelec.FindAsync(id);
            _context.Comelec.Remove(comelec);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComelecExists(int id)
        {
            return _context.Comelec.Any(e => e.id == id);
        }
    }
}
