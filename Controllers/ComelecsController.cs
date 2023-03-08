using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VotingSystem.Data;
using VotingSystem.Models;

namespace VotingSystem.Controllers
{
    public class ComelecsController : Controller
    {
        private readonly ApplicationDbContext _context;

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
                return RedirectToAction(nameof(Index));
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
