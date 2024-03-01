using System.Drawing;

namespace api.Models;

public class Roulette
{
    public int Result { get; set; }
    public string Color { get; set; }
    public bool IsEven { get; set; }
    public double Chips { get; set; }
    public double Einsatz { get; set; }
    public string Wette { get; set; }
}