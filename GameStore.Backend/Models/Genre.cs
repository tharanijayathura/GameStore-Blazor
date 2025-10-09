using System.ComponentModel.DataAnnotations;

namespace GameStore.Backend.Models;

public class Genre
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;

    // Navigation property
    public ICollection<Game> Games { get; set; } = new List<Game>();
}