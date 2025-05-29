using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FootballApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballApp.Controllers;

[Authorize]
public class StatsController : Controller
{
    private readonly FootballLeagueContext _context;

    public StatsController(FootballLeagueContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        ViewData["MenuTitle"] = "Player Stats";
        var stats = _context.StatystykiZawodnikow.Include(s => s.Zawodnik).ToList();
        return View(stats);
    }

    public IActionResult Edit(int id)
    {
        var stat = _context.StatystykiZawodnikow
            .Include(s => s.Zawodnik)
            .FirstOrDefault(s => s.Id == id);

        if (stat == null)
            return NotFound();

        return View(stat);
    }

    [HttpPost]
    public IActionResult Edit(int id, StatystykiZawodnika updatedStats)
    {
        if (id != updatedStats.Id)
            return BadRequest();

        if (ModelState.IsValid)
        {
            _context.Update(updatedStats);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        return View(updatedStats);
    }
    
    public IActionResult KrolStrzelcow()
    {
        var topScorers = _context.StatystykiZawodnikow
            .Include(s => s.Zawodnik)
            .OrderByDescending(s => s.Gole)
            .Take(3)
            .ToList();

        return View(topScorers);
    }

}
