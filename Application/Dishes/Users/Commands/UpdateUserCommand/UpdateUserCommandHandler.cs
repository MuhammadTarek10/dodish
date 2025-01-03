using MediatR;
using Microsoft.AspNetCore.Identity;

using Domain.Exceptions;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Users;

public class UpdateUserCommandHandler(
    ILogger<UpdateUserCommandHandler> logger,
    IUserContext context,
    IUserStore<User> store) : IRequestHandler<UpdateUserCommand>
{
    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        CurrentUser? user = context.GetCurrentUser();

        if (user is null) throw new ForbidException();

        User? dbUser = await store.FindByIdAsync(user.Id, cancellationToken);

        if (dbUser is null) throw new NotFoundException(nameof(User), user.Id);

        dbUser.DateOfBirth = request.DateOfBirth;
        dbUser.Nationality = request.Nationality;

        logger.LogInformation("User Updated: {@updated}", dbUser);

        await store.UpdateAsync(dbUser, cancellationToken);
    }
}
