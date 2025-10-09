using GameStore.Backend.Dtos;

namespace GameStore.Backend.Repositories;

public interface IGameRepository
{
    Task<IEnumerable<GameDto>> GetAllGamesAsync();
    Task<GameDto?> GetGameByIdAsync(int id);
    Task<GameDto> CreateGameAsync(CreateGameDto gameDto);
    Task<GameDto?> UpdateGameAsync(int id, UpdateGameDto gameDto);
    Task<bool> DeleteGameAsync(int id);
    Task<bool> GameExistsAsync(int id);
}