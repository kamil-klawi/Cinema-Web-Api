using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CinemaEntities = Cinema.Domain.Entities;

namespace Cinema.Infrastructure.Persistence;

public class CinemaDbContext(DbContextOptions<CinemaDbContext> options) : IdentityDbContext<CinemaEntities.User>(options)
{
    internal DbSet<CinemaEntities.Cinema> Cinemas { get; set; }
    internal DbSet<CinemaEntities.Movie> Movies { get; set; }
    internal DbSet<CinemaEntities.Actor> Actors { get; set; }
    internal DbSet<CinemaEntities.Director> Directors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<CinemaEntities.Cinema>()
            .OwnsOne(c => c.Address);
        
        modelBuilder.Entity<CinemaEntities.Cinema>()
            .HasMany(c => c.Movies)
            .WithMany(m => m.Cinemas);
        
        modelBuilder.Entity<CinemaEntities.Movie>()
            .HasOne(m => m.Director)
            .WithMany(d => d.Movies)
            .HasForeignKey(m => m.DirectorId);

        modelBuilder.Entity<CinemaEntities.Movie>()
            .HasMany(m => m.Actors)
            .WithMany(a => a.Movies);
    }
}