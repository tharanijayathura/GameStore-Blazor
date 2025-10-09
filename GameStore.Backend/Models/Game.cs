using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Backend.Models;

public class Game
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public int GenreId { get; set; }

    [ForeignKey(nameof(GenreId))]
    public Genre? Genre { get; set; }

    [Range(0, 1000)]
    public decimal Price { get; set; }

    public DateOnly ReleaseDate { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}