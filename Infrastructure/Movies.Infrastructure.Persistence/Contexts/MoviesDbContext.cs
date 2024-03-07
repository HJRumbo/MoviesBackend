using Microsoft.EntityFrameworkCore;
using Movies.Core.Domain.Entities;

namespace Movies.Infrastructure.Persistence.Contexts
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Category>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Category>()
                .HasMany(x => x.Movies)
                .WithOne(m => m.Category)
                .HasForeignKey(x => x.CategoryId);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
