
using MediatR;

namespace Application.Users;

public class UpdateUserCommand : IRequest
{
    public DateOnly? DateOfBirth { get; set; }
    public string? Nationality { get; set; }
}

