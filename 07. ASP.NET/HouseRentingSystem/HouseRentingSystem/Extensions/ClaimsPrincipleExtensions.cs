using System.Security.Claims;

namespace System.Security.Claims;

public static class ClaimsPrincipleExtensions
{
    public static string Id(this ClaimsPrincipal user) => user.FindFirstValue(ClaimTypes.NameIdentifier);
}