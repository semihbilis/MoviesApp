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
            optionsBuilder.UseSqlServer($"Server=.;Database=MoviesApp;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>()
                .Property(x => x.GenreIds)
                .HasConversion(x => string.Join(",", x),
                               x => x.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
        }
    }
}