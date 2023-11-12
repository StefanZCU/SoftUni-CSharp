namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [MaxLength(ValidationConstants.UserUsernameMaxLength)]
    public string Username { get; set; }

    [Required]
    [MaxLength(ValidationConstants.UserPasswordMaxLength)]
    public string Password { get; set; }

    [Required]
    [MaxLength(ValidationConstants.UserEmailMaxLength)]
    public string Email { get; set; }

    [Required]
    [MaxLength(ValidationConstants.UserNameMaxLength)]
    public string Name { get; set; }

    public decimal Balance { get; set; }

}