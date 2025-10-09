using Microsoft.EntityFrameworkCore;
using GameStore.Backend.Models;

namespace GameStore.Backend.Data;

public class GameStoreDbContext : DbContext
{
    public GameStoreDbContext(DbContextOptions<GameStoreDbContext> options) : base(options)
    {
    }

    public DbSet<Game> Games { get; set; }
    public DbSet<Genre> Genres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure decimal precision for Price to avoid the warning
        modelBuilder.Entity<Game>()
            .Property(g => g.Price)
            .HasPrecision(18, 2); // This fixes the decimal warning

        // Seed genres
        modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, Name = "Fighting" },
            new Genre { Id = 2, Name = "Roleplaying" },
            new Genre { Id = 3, Name = "Sports" },
            new Genre { Id = 4, Name = "Racing" },
            new Genre { Id = 5, Name = "Kids and Family" },
            new Genre { Id = 6, Name = "Adventure" },
            new Genre { Id = 7, Name = "Sandbox" }
        );

        // Seed sample games
        modelBuilder.Entity<Game>().HasData(
            new Game 
            { 
                Id = 1, 
                Name = "Street Fighter II", 
                GenreId = 1, 
                Price = 19.99M, 
                ReleaseDate = new DateOnly(2017, 3, 3),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Game 
            { 
                Id = 2, 
                Name = "The Zelda", 
                GenreId = 6, 
                Price = 29.99M, 
                ReleaseDate = new DateOnly(1998, 11, 21),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Game 
            { 
                Id = 3, 
                Name = "Minecraft", 
                GenreId = 7, 
                Price = 26.95M, 
                ReleaseDate = new DateOnly(2011, 11, 18),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        );
    }
}