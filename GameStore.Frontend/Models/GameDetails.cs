using System;
using System.ComponentModel.DataAnnotations;
using GameStore.Frontend.Components.Pages;

namespace GameStore.Frontend.Models;

public class GameDetails
{
    public int Id { get; set; }
    [Required]
    [StringLength(50)]

    public required string Name { get; set; }

    [Required(ErrorMessage = "Genre is required")]
    public int GenreId { get; set; }

    [Range(0, 100)]
    public decimal Price { get; set; }


    public DateOnly ReleaseDate { get; set; }
}