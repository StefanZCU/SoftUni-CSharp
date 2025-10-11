using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static HouseRentingSystem.Infrastructure.Constants.DataConstants;

namespace HouseRentingSystem.Infrastructure.Data.Models;

[Comment("House categories")]
public class Category
{
    [Key]
    [Comment("Category ID")]
    public int Id { get; set; }

    [Required]
    [MaxLength(CategoryNameMaxLength)]
    [Comment("Category Name")]
    public required string Name { get; set; }

    [Comment("Houses with this category")]
    public IEnumerable<House> Houses { get; set; } = new List<House>();
}