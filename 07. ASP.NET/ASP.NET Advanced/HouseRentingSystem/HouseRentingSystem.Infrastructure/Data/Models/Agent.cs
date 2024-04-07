using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HouseRentingSystem.Infrastructure.Data.Constants.DataConstants;

namespace HouseRentingSystem.Infrastructure.Data.Models;

public class Agent
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(AgentPhoneNumberMaxLength)]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    public string UserId { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public IdentityUser User { get; set; } = null!;
}