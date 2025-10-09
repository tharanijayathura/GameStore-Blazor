using GameStore.Backend.Dtos;

namespace GameStore.Backend.Repositories;

public interface IGenreRepository
{
    Task<IEnumerable<GenreDto>> GetAllGenresAsync();
    Task<GenreDto?> GetGenreByIdAsync(int id);
}