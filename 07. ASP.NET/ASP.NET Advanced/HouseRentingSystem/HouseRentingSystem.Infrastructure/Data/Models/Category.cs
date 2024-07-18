using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static HouseRentingSystem.Infrastructure.Constants.DataConstants;

namespace HouseRentingSystem.Infrastructure.Data.Models;

[Comment("House category")]
public class Category
{
    [Key]
    [Comment("Category Identifier")]
    public int Id { get; set; }

    [Required]
    [MaxLength(CategoryNameMaxLength)]
    [Comment("Category Name")]
    public string Name { get; set; } = null!;

    [Comment("Category Houses")]
    public List<House> Houses { get; set; } = new List<House>();
}