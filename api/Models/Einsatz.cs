using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Einsatz
    {
        public int Id { get; set; }
        public double UserEinsatz { get; set; }
        public string UserName { get; set; }
    }
}
