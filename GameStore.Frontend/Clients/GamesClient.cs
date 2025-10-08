using System;
using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient
{
    private readonly List<GameSummary> games =
    [
        new(){
            Id=1,
            Name="Street Fighter II",
            Genre="Fighting",
            Price=19.99M,
            ReleaseDate=new DateOnly(2017,3,3)
        },
        new(){
            Id=2,
            Name="The Zelda",
            Genre="Adventure",
            Price=29.99M,
            ReleaseDate=new DateOnly(1998,11,21)
        },
        new(){
            Id=3,
            Name="Minecraft",
            Genre="Sandbox",
            Price=26.95M,
            ReleaseDate=new DateOnly(2011,11,18)
        }
    ];

    private readonly Genre[] genres = new GenresClient().GetGenres();

    public GameSummary[] GetGames() => [.. games];

    public void AddGame(GameDetails game)
    {
        Genre genre = GetGenreById(game.GenreId.ToString());

        var gameSummary = new GameSummary
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };

        games.Add(gameSummary);
    }


    public GameDetails GetGame(int id)
    {
        GameSummary game = GetGameSummarById(id);

        var genre = genres.Single(genre => string.Equals(
            genre.Name,
            game.Genre,
            StringComparison.OrdinalIgnoreCase));

        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

    public void UpdateGame(GameDetails updatedGame)
    {
        var genre = GetGenreById(updatedGame.GenreId.ToString());
        GameSummary existingGame = GetGameSummarById(updatedGame.Id);

        existingGame.Name = updatedGame.Name;
        existingGame.Genre = genre.Name;
        existingGame.Price = updatedGame.Price;
        existingGame.ReleaseDate = updatedGame.ReleaseDate;
    }

    private GameSummary GetGameSummarById(int id)
    {
        GameSummary? game = games.Find(game => game.Id == id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }
    
        private Genre GetGenreById(string? id)
    {
        ArgumentException.ThrowIfNullOrEmpty(id);
        return genres.Single(genre => genre.Id == int.Parse(id));

    }
}