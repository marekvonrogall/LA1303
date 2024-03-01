using System.Drawing;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class WetteController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Wette>> PostWette(string userWette, string userName)
    {
        if (int.TryParse(userWette, out int userNumber))
        {
            if (Convert.ToInt32(userWette) < 0 || Convert.ToInt32(userWette) > 36) { return BadRequest("Ungültige Wette erkannt."); }
        }
        else
        {
            if (userWette.ToLower() == "red" || userWette.ToLower() == "black" || userWette.ToLower() == "q1" || userWette.ToLower() == "q2" || userWette.ToLower() == "q3") { }
            else return BadRequest("Ungültige Wette erkannt.");
        }

        Wette wette = new Wette();
        wette.UserWette = userWette;
        wette.UserName = userName;
        using (var _context = new SpeicherDb())
        {
            var benutzer = _context.Benutzer.FirstOrDefault(d => d.Name == userName);
            if(benutzer != null)
            {
                _context.Wette.Add(wette);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(PostWette), new { id = wette.Id }, wette);
            }
            else
            {
                return BadRequest("Dieser Benutzer konnte nicht gefunden werden.");
            }
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Wette>>> GetWette()
    {
        using (var _context = new SpeicherDb())
        {
            return await _context.Wette.ToListAsync();
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Wette>> GetWette(int id)
    {
        using (var _context = new SpeicherDb())
        {
            var wette = await _context.Wette.FindAsync(id);

            if (wette == null)
            {
                return NotFound();
            }

            return wette;
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWette(int id)
    {
        using (var _context = new SpeicherDb())
        {
            var wette = await _context.Wette.FindAsync(id);

            if (wette == null)
            {
                return NotFound();
            }

            _context.Wette.Remove(wette);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
