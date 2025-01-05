using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Authorization;

public class MinimumAgeRequirement(int minimumAge) : IAuthorizationRequirement
{
    public int MinimumAge { get; } = minimumAge;
}
