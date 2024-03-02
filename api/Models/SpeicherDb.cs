using Microsoft.EntityFrameworkCore;


namespace api.Models
{
    public class SpeicherDb : DbContext
    {
        public DbSet<Wette> Wette { get; set; }
        public DbSet<Einsatz> Einsatz { get; set; }
        public DbSet<Benutzer> Benutzer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=RouletteDatenbank;Trusted_Connection=True";
            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
