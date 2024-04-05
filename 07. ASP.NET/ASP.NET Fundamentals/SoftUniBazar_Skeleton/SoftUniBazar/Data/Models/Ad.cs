using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using static SoftUniBazar.Data.DataConstants;

namespace SoftUniBazar.Data.Models;

public class Ad
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(AdNameMaxLength)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(AdDescriptionMaxLength)]
    public string Description { get; set; } = string.Empty;

    [Required]
    public decimal Price { get; set; }

    [Required]
    public string OwnerId { get; set; } = string.Empty;

    [ForeignKey(nameof(OwnerId))] 
    public IdentityUser Owner { get; set; } = null!;

    [Required]
    public string ImageUrl { get; set; } = string.Empty;
    
    [Required]
    public DateTime CreatedOn { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; } = null!;
}