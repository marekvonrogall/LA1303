using System.Drawing;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class EinsatzController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Einsatz>> PostEinsatz(int userEinsatz, string userName)
    {
        if (userEinsatz <= 0)
        {
            return BadRequest("Ungültigen Einsatz erkannt.");
        }

        using (var _context = new SpeicherDb())
        {
            var benutzer = _context.Benutzer.FirstOrDefault(d => d.Name == userName);

            if (benutzer != null)
            {
                if (benutzer.Chips >= userEinsatz)
                {
                    Einsatz einsatz = new Einsatz();
                    einsatz.UserEinsatz = userEinsatz;
                    einsatz.UserName = userName;

                    // Genug Chips
                    _context.Einsatz.Add(einsatz);
                    benutzer.Chips -= userEinsatz;

                    await _context.SaveChangesAsync();
                    return CreatedAtAction(nameof(PostEinsatz), new { id = einsatz.Id }, einsatz);
                }
                else
                {
                    return BadRequest("Dieser Benutzer hat zu wenig Chips um diesen Einsatz zu platzieren.");
                }
            }
            else
            {
                return BadRequest("Dieser Benutzer konnte nicht gefunden werden.");
            }
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Einsatz>>> GetEinsatz()
    {
        using (var _context = new SpeicherDb())
        {
            return await _context.Einsatz.ToListAsync();
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Einsatz>> GetEinsatz(int id)
    {
        using (var _context = new SpeicherDb())
        {
            var einsatz = await _context.Einsatz.FindAsync(id);

            if (einsatz == null)
            {
                return NotFound();
            }

            return einsatz;
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEinsatz(int id)
    {
        using (var _context = new SpeicherDb())
        {
            var einsatz = await _context.Einsatz.FindAsync(id);

            if (einsatz == null)
            {
                return NotFound();
            }

            // Chips hinzufügen wenn ein Einsatz zurückgezogen wird.
            var benutzer = _context.Benutzer.FirstOrDefault(d => d.Name == einsatz.UserName);
            benutzer.Chips += einsatz.UserEinsatz;

            _context.Einsatz.Remove(einsatz);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
