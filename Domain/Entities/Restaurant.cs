using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Restaurant : IEntityWithGuidId
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

    public Address? Address { get; set; }

    public List<Dish> Dishes { get; set; } = [];
}
