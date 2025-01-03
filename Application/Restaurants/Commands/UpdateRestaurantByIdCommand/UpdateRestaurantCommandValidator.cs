using FluentValidation;

namespace Application.Restaurants.Commands;

public class UpdateRestaurantCommandValidator : AbstractValidator<UpdateRestaurantCommand>
{
    public UpdateRestaurantCommandValidator()
    {
        RuleFor(c => c.Name)
            .Length(3, 100);
    }
}
