using Microsoft.EntityFrameworkCore;
using GameStore.Backend.Data;
using GameStore.Backend.Models;
using GameStore.Backend.Dtos;

namespace GameStore.Backend.Repositories;

public class GameRepository : IGameRepository
{
    private readonly GameStoreDbContext _context;

    public GameRepository(GameStoreDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GameDto>> GetAllGamesAsync()
    {
        return await _context.Games
            .Include(g => g.Genre)
            .Select(g => new GameDto
            {
                Id = g.Id,
                Name = g.Name,
                GenreId = g.GenreId,
                GenreName = g.Genre!.Name,
                Price = g.Price,
                ReleaseDate = g.ReleaseDate
            })
            .ToListAsync();
    }

    public async Task<GameDto?> GetGameByIdAsync(int id)
    {
        var game = await _context.Games
            .Include(g => g.Genre)
            .FirstOrDefaultAsync(g => g.Id == id);

        if (game == null) return null;

        return new GameDto
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = game.GenreId,
            GenreName = game.Genre!.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

    public async Task<GameDto> CreateGameAsync(CreateGameDto gameDto)
    {
        var game = new Game
        {
            Name = gameDto.Name,
            GenreId = gameDto.GenreId,
            Price = gameDto.Price,
            ReleaseDate = gameDto.ReleaseDate,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Games.Add(game);
        await _context.SaveChangesAsync();

        var createdGame = await _context.Games
            .Include(g => g.Genre)
            .FirstAsync(g => g.Id == game.Id);

        return new GameDto
        {
            Id = createdGame.Id,
            Name = createdGame.Name,
            GenreId = createdGame.GenreId,
            GenreName = createdGame.Genre!.Name,
            Price = createdGame.Price,
            ReleaseDate = createdGame.ReleaseDate
        };
    }

    public async Task<GameDto?> UpdateGameAsync(int id, UpdateGameDto gameDto)
    {
        var game = await _context.Games.FindAsync(id);
        if (game == null) return null;

        game.Name = gameDto.Name;
        game.GenreId = gameDto.GenreId;
        game.Price = gameDto.Price;
        game.ReleaseDate = gameDto.ReleaseDate;
        game.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        var updatedGame = await _context.Games
            .Include(g => g.Genre)
            .FirstAsync(g => g.Id == game.Id);

        return new GameDto
        {
            Id = updatedGame.Id,
            Name = updatedGame.Name,
            GenreId = updatedGame.GenreId,
            GenreName = updatedGame.Genre!.Name,
            Price = updatedGame.Price,
            ReleaseDate = updatedGame.ReleaseDate
        };
    }

    public async Task<bool> DeleteGameAsync(int id)
    {
        var game = await _context.Games.FindAsync(id);
        if (game == null) return false;

        _context.Games.Remove(game);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> GameExistsAsync(int id)
    {
        return await _context.Games.AnyAsync(g => g.Id == id);
    }
}