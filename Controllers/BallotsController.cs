    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;
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

        // GET: Ballots
        // GET: Ballots
        public IActionResult Index()
        {
            var ballots = _context.Ballots
                            .Include(b => b.candidate)
                            .Include(b => b.position)
                            .ToList();

            var positions = ballots.Select(b => b.position).Distinct().ToList();

            ViewData["positionsId"] = new SelectList(positions, "Id", "Name");

            return View(ballots);
        }


        // GET: Ballots/Create
        public IActionResult Create()
            {
                var ballots = _context.Ballots
                                  .Include(b => b.candidate)
                                  .Include(b => b.position)
                                  .ToList();

            

                var positions = ballots.Select(b => b.position).Distinct().ToList();
                var candidates = ballots.Select(b => b.candidate).Distinct().ToList();

                ViewData["positionsId"] = new SelectList(positions, "Id", "Name");
                ViewData["candidatesId"] = new SelectList(candidates, "Id", "Name");

                return View();
            }

            // POST: Ballots/Create
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

                var positions = _context.Positions.ToList();
                var candidates = _context.Candidates.ToList();
                ViewData["positionId"] = new SelectList(positions, "Id", "Name");
                ViewData["candidateId"] = new SelectList(candidates, "Id", "Name");

                return View(ballots);
            }
        }
    }
