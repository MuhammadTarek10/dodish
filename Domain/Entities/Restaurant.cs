using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Restaurant
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = default!;

    [Required]
    [MaxLength(250)]
    public string Description { get; set; } = default!;

    public Address? Address { get; set; }

    public List<Dish> Dishes { get; set; } = new();

}
