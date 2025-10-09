using Microsoft.EntityFrameworkCore;
using GameStore.Backend.Data;
using GameStore.Backend.Dtos;

namespace GameStore.Backend.Repositories;

public class GenreRepository : IGenreRepository
{
    private readonly GameStoreDbContext _context;

    public GenreRepository(GameStoreDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GenreDto>> GetAllGenresAsync()
    {
        return await _context.Genres
            .Select(g => new GenreDto
            {
                Id = g.Id,
                Name = g.Name
            })
            .ToListAsync();
    }

    public async Task<GenreDto?> GetGenreByIdAsync(int id)
    {
        var genre = await _context.Genres.FindAsync(id);
        if (genre == null) return null;

        return new GenreDto
        {
            Id = genre.Id,
            Name = genre.Name
        };
    }
}