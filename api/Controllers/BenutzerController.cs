using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BenutzerController : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<Wette>> PostBenutzer(string username, string password)
        {
            Benutzer benutzer = new Benutzer();
            benutzer.Name = username;
            benutzer.Password = password;
            benutzer.Chips = 2000;
            using (var _context = new SpeicherDb())
            {
                _context.Benutzer.Add(benutzer);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(PostBenutzer), new { id = benutzer.Id }, benutzer);

            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetBenutzer()
        {
            using (var _context = new SpeicherDb())
            {
                var benutzerList = await _context.Benutzer
                    .Select(b => new { b.Id, b.Name, b.Chips })
                    .ToListAsync();

                return benutzerList;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetBenutzer(int id)
        {
            using (var _context = new SpeicherDb())
            {
                var benutzer = await _context.Benutzer
                    .Where(b => b.Id == id)
                    .Select(b => new { b.Id, b.Name, b.Chips })
                    .FirstOrDefaultAsync();

                if (benutzer == null)
                {
                    return NotFound();
                }

                return benutzer;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Benutzer>> DeleteBenutzer(int id)
        {
            using (var _context = new SpeicherDb())
            {
                var benutzer = await _context.Benutzer.FindAsync(id);
                if (benutzer == null)
                {
                    return NotFound();
                }

                _context.Benutzer.Remove(benutzer);
                await _context.SaveChangesAsync();

                return benutzer;
            }
        }
    }
}
