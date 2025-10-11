using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static HouseRentingSystem.Infrastructure.Constants.DataConstants;

namespace HouseRentingSystem.Infrastructure.Data.Models;

[Comment("Agents")]
public class Agent
{
   [Key]
   [Comment("Agent ID")]
   public int Id { get; set; }

   [Required]
   [MaxLength(AgentPhoneNumberMaxLength)]
   [Comment("Agent Phone Number")]
   public required string PhoneNumber { get; set; }

   [Required]
   [Comment("Agent Username")]
   public required string UserId { get; set; }

   [ForeignKey(nameof(UserId))]
   public IdentityUser User { get; set; } = null!;

}