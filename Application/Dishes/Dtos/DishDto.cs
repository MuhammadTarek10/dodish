namespace Application.Dtos;

public record DishDto(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    int? KiloCalories
);
