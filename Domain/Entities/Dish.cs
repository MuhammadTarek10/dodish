using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Dish
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = default!;

    [Required]
    [MaxLength(200)]
    public string Description { get; set; } = default!;

    [Required]
    public decimal Price { get; set; }

    public int? KiloCalories { get; set; }

    [Required]
    [ForeignKey("Resatuarant")]
    public Guid RestaurantId { get; set; }

    [NotMapped]
    public required Restaurant Restaurant { get; set; }
}
