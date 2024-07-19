using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static HouseRentingSystem.Infrastructure.Constants.DataConstants;

namespace HouseRentingSystem.Infrastructure.Data.Models;

[Index(nameof(PhoneNumber), IsUnique = true)]
[Comment("Agents")]
public class Agent
{
    [Key]
    [Comment("Agent Identifier")]
    public int Id { get; set; }

    [Required]
    [MaxLength(AgentPhoneNumberMaxLength)]
    [Comment("Agent Phone Number")]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    [Comment("User Identifier")]
    public string UserId { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public IdentityUser User { get; set; } = null!;
}