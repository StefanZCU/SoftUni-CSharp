using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static HouseRentingSystem.Infrastructure.Constants.DataConstants;

namespace HouseRentingSystem.Infrastructure.Data.Models;

[Comment("House To Rent")]
public class House
{
    [Key]
    [Comment("House Identifier")]
    public int Id { get; set; }

    [Required]
    [MaxLength(HouseTitleMaxLength)]
    [Comment("House Title")]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(HouseAddressMaxLength)]
    [Comment("House Address")]
    public string Address { get; set; } = null!;

    [Required]
    [MaxLength(HouseDescriptionMaxLength)]
    [Comment("House Description")]
    public string Description { get; set; } = null!;

    [Required]
    [Comment("House Image URL")]
    public string ImageUrl { get; set; } = null!;

    [Required]
    //[Range(typeof(decimal), HousePricePerMonthMinLength, HousePricePerMonthMaxLength, ConvertValueInInvariantCulture = true)]
    [Comment("House Price Per Month")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal PricePerMonth { get; set; }

    [Required]
    [Comment("House Category Identifier")]
    public int CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; } = null!;

    [Required]
    [Comment("House Agent Identifier")]
    public int AgentId { get; set; }

    [ForeignKey(nameof(AgentId))]
    public Agent Agent { get; set; } = null!;

    [Comment("House Renter Identifier")]
    public string? RenterId { get; set; }

    [Comment("Is house approved by admin")]
    public bool IsApproved { get; set; }
}
