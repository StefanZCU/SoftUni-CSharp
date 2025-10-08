using Microsoft.AspNetCore.Identity;

namespace TaskBoardApp.Data.Configuration;

public static class ConfigurationHelper
{
    public static IdentityUser TestUser = GetUser();

    public static Board OpenBoard = new()
    {
        Id = 1,
        Name = "Open",
    };

    public static Board InProgressBoard = new()
    {
        Id = 2,
        Name = "In Progress",
    };

    public static Board DoneBoard = new()
    {
        Id = 3,
        Name = "Done",
    };
    
    private static IdentityUser GetUser()
    {
        var hasher = new PasswordHasher<IdentityUser>();

        var user = new IdentityUser()
        {
            UserName = "test@softuni.bg",
            NormalizedUserName = "TEST@SOFTUNI.BG"
        };
        
        user.PasswordHash = hasher.HashPassword(user, "softuni");
        return user;
    }
}