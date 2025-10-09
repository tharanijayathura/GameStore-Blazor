namespace GameStore.Backend.Dtos;

public class GameDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int GenreId { get; set; }
    public string? GenreName { get; set; }
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}

public class CreateGameDto
{
    public required string Name { get; set; }
    public int GenreId { get; set; }
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}

public class UpdateGameDto
{
    public required string Name { get; set; }
    public int GenreId { get; set; }
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}