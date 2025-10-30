using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static HouseRentingSystem.Infrastructure.Constants.DataConstants;

namespace HouseRentingSystem.Infrastructure.Data.Models;

[Comment("House")]
public class House
{
    [Key]
    [Comment("House ID")]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(HouseTitleMaxLength)]
    [Comment("House Title")]
    public required string Title { get; set; }

    [Required]
    [MaxLength(HouseAddressMaxLength)]
    [Comment("House Address")]
    public required string Address { get; set; }

    [Required]
    [MaxLength(HouseDescriptionMaxLength)]
    [Comment("House Description")]
    public required string Description { get; set; }

    [Required]
    public required string ImageUrl { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    [Comment("House Price per Month")]
    public decimal PricePerMonth { get; set; }

    [Required]
    [Comment("House Category")]
    public int CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; } = null!;

    [Required]
    [Comment("House agent")]
    public int AgentId { get; set; }

    [ForeignKey(nameof(AgentId))]
    public Agent Agent { get; set; } = null!;
    
    [Comment("Renter ID")]
    public string? RenterId { get; set; }
    
    [ForeignKey(nameof(RenterId))]
    public ApplicationUser? Renter { get; set; }

    [Comment("Is house approved by Admin")]
    public bool IsApproved { get; set; }
}