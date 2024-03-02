using System.Drawing;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class RouletteController : ControllerBase
{
    [HttpGet(Name = "GetRouletteResult")]
    public IActionResult Get()
    {
        using (var _context = new SpeicherDb())
        {
            Random random = new Random();
            int generatedNumber = random.Next(0, 37);
            
            string generatedColor = null;
            switch (generatedNumber % 2)
            {
                case 0: generatedColor = "red"; break;
                case 1: generatedColor = "black"; break;
            }
            if (generatedNumber == 0) generatedColor = "green";

            // Alle Wetten bekommen
            var allUserBets = _context.Wette.ToList();

            foreach (var userBet in allUserBets)
            {
                // Wette von jedem Benutzer auf Gewinne überprüfen.
                bool userWins = CheckUserBet(userBet.UserWette, generatedNumber);

                // Benutzer bekommen
                var user = _context.Benutzer.FirstOrDefault(u => u.Name == userBet.UserName);

                if (user != null)
                {
                    // BenutzerWette bekommen
                    var userEinsatzEntry = _context.Einsatz.FirstOrDefault(e => e.UserName == userBet.UserName);

                    if (userEinsatzEntry == null || userEinsatzEntry.UserEinsatz == 0)
                    {
                        return BadRequest(new { Message = "Einsatz fehlerhaft." });
                    }

                    if (userWins)
                    {
                        // Der Benutzer gewinnt seinen Einsatz * Multiplier
                        double multiplier = GetMultiplier(userBet.UserWette, generatedNumber);
                        double winnings = userEinsatzEntry.UserEinsatz * multiplier;
                        user.Chips += winnings;
                    }

                    // Einsatz löschen, da er schon bearbeitet wurde.
                    _context.Einsatz.Remove(userEinsatzEntry);
                    _context.SaveChanges();
                }
            }


            // Alle Einsätze und Wetten werden zurückgesetzt.
            _context.Einsatz.RemoveRange(_context.Einsatz);
            _context.Wette.RemoveRange(_context.Wette);
            _context.SaveChanges();

            return Ok(new
            {
                GeneratedNumber = generatedNumber,
                GeneratedColor = generatedColor
            });
        }
    }

    private bool CheckUserBet(string userBet, int generatedNumber)
    {
        if (int.TryParse(userBet, out int userNumber))
        {
            //Wenn die Zahlen gleich sind return true
            return generatedNumber == userNumber;
        }
        else if (userBet.ToLower() == "red" || userBet.ToLower() == "black")
        {
            string generatedColor = null;
            switch (generatedNumber % 2)
            {
                case 0: generatedColor = "red"; break;
                case 1: generatedColor = "black"; break;
            }
            if (generatedNumber == 0) generatedColor = "green";

            //Wenn die Zahl rot / schwarz / grün ist und der User diese Farbe ausgewählt hat return true
            return userBet.ToLower() == generatedColor;
        }
        else if (userBet.ToLower() == "q1" || userBet.ToLower() == "q2" || userBet.ToLower() == "q3")
        {
            //Wenn der User auf einen Sektor gesetzt hat und eine Zahl in diesem Sektor generiert wurde.
            string generatedSector = "?";

            switch (generatedNumber)
            {
                case int n when (n <= 12 && n >= 1):
                    generatedSector = "q1";
                    break;
                case int n when (n <= 24 && n >= 13):
                    generatedSector = "q2";
                    break;
                case int n when (n <= 36 && n >= 25):
                    generatedSector = "q3";
                    break;
                default:
                    generatedSector = "?";
                    break;
            }

            return generatedSector == userBet.ToLower();
        }

        return false;
    }

    private double GetMultiplier(string userBet, int generatedNumber)
    {
        if (int.TryParse(userBet, out int userNumber))
        {
            // Multiplier bei einzelnen Zahlen (35)
            return 35;
        }
        else if (userBet.ToLower() == "red" || userBet.ToLower() == "black")
        {
            // Multiplier bei Farben (2)
            return 2;
        }
        else if (userBet.ToLower() == "q1" || userBet.ToLower() == "q2" || userBet.ToLower() == "q3")
        {
            // Multiplier bei Sektoren (3)

            return 3;
        }

        return 0;
    }
}