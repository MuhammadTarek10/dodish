using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Application.Users;

public interface IUserContext
{
    CurrentUser? GetCurrentUser();
}

internal class UserContext(IHttpContextAccessor http) : IUserContext
{
    public CurrentUser? GetCurrentUser()
    {
        var user = http.HttpContext?.User;

        if (user is null) throw new InvalidOperationException("User context is not present");

        if (user.Identity == null || !user.Identity.IsAuthenticated) return null;

        string userId = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        string email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;
        IEnumerable<string> roles = user.Claims.Where(c => c.Type == ClaimTypes.Role)!.Select(c => c.Value);
        string? nationality = user.FindFirst(c => c.Type == "Nationality")?.Value;
        string? dateOfBirthString = user.FindFirst(c => c.Type == "DateOfBirth")?.Value;
        DateOnly? dateOfBirth = dateOfBirthString == null
            ? (DateOnly?)null
            : DateOnly.ParseExact(dateOfBirthString, "yyyy-MM-dd");

        return new CurrentUser(userId, email, roles, nationality, dateOfBirth);
    }
}
