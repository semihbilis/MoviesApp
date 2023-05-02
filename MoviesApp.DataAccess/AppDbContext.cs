using Microsoft.EntityFrameworkCore;
using MoviesApp.Entity;

namespace MoviesApp.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("Server=.;Database=MoviesApp;Trusted_Connection=True;TrustServerCertificate=True;");
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MoviesApp;Integrated Security=True;Connect Timeout=30");
        }
    }
}