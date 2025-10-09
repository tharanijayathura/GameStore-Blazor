using Microsoft.AspNetCore.Mvc;
using GameStore.Backend.Dtos;
using GameStore.Backend.Repositories;

namespace GameStore.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase
{
    private readonly IGameRepository _gameRepository;

    public GamesController(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GameDto>>> GetGames()
    {
        var games = await _gameRepository.GetAllGamesAsync();
        return Ok(games);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GameDto>> GetGame(int id)
    {
        var game = await _gameRepository.GetGameByIdAsync(id);
        if (game == null)
        {
            return NotFound();
        }
        return Ok(game);
    }

    [HttpPost]
    public async Task<ActionResult<GameDto>> CreateGame(CreateGameDto gameDto)
    {
        var createdGame = await _gameRepository.CreateGameAsync(gameDto);
        return CreatedAtAction(nameof(GetGame), new { id = createdGame.Id }, createdGame);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<GameDto>> UpdateGame(int id, UpdateGameDto gameDto)
    {
        if (!await _gameRepository.GameExistsAsync(id))
        {
            return NotFound();
        }

        var updatedGame = await _gameRepository.UpdateGameAsync(id, gameDto);
        if (updatedGame == null)
        {
            return NotFound();
        }

        return Ok(updatedGame);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteGame(int id)
    {
        var result = await _gameRepository.DeleteGameAsync(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}