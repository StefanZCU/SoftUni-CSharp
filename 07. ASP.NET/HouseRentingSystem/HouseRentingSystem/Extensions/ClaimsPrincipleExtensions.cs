using System.Security.Claims;
using static HouseRentingSystem.Core.Constants.RoleConstants;

namespace System.Security.Claims;

public static class ClaimsPrincipleExtensions
{
    public static string Id(this ClaimsPrincipal user)
        => user.FindFirstValue(ClaimTypes.NameIdentifier);

    public static bool IsAdmin(this ClaimsPrincipal user) 
        => user.IsInRole(AdminRole);
}