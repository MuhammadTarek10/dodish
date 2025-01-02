using System.ComponentModel.DataAnnotations;

namespace Application.Dtos;

public class RestaurantDto
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = default!;

    [Required]
    [MaxLength(50)]
    public string Category { get; set; } = default!;

    [Required]
    [MaxLength(250)]
    public string Description { get; set; } = default!;

    [Required]
    public bool HasDelivery { get; set; } = false;

    [Phone]
    public string? ContactNumber { get; set; }

    [EmailAddress]
    [MaxLength(50)]
    public string? ContactEmail { get; set; }

    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }

    public List<DishDto> Dishes { get; set; } = [];
}
