using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Infrastructure.Data.Constants.DataConstants;

namespace HouseRentingSystem.Infrastructure.Data.Models;

public class Category
{
    [Key]
    public int Id { get; init; }

    [Required]
    [MaxLength(CategoryNameMaxLength)]
    public string Name { get; set; } = null!;

    public IEnumerable<House> Houses { get; init; } = new List<House>();
}