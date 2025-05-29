using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FootballApp.Models;

[Route("api/[controller]")]
[ApiController]
public class PlayersApiController : ControllerBase
{
    private readonly FootballLeagueContext _context;

    public PlayersApiController(FootballLeagueContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Zawodnicy.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var player = _context.Zawodnicy.Find(id);
        return player == null ? NotFound() : Ok(player);
    }

    [HttpPost]
    public IActionResult Create(Zawodnik zawodnik)
    {
        _context.Zawodnicy.Add(zawodnik);
        _context.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = zawodnik.Id }, zawodnik);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Zawodnik updated)
    {
        var existing = _context.Zawodnicy.Find(id);
        if (existing == null) return NotFound();

        existing.Imie = updated.Imie;
        existing.Nazwisko = updated.Nazwisko;
        existing.Pozycja = updated.Pozycja;
        existing.DruzynaId = updated.DruzynaId;

        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var zawodnik = _context.Zawodnicy.Find(id);
        if (zawodnik == null) return NotFound();

        _context.Zawodnicy.Remove(zawodnik);
        _context.SaveChanges();
        return NoContent();
    }
}
