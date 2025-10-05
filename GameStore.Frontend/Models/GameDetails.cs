using System;

namespace GameStore.Frontend.Models;

public class GameDetails
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public int GenreId { get; set; }

    public decimal Price { get; set; }

    public DateOnly ReleaseDate { get; set; }
}