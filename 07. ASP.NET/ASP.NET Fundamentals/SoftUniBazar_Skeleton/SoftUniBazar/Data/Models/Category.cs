using System.ComponentModel.DataAnnotations;

namespace SoftUniBazar.Data.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(DataConstants.CategoryNameMaxLength)]
    public string Name { get; set; } = string.Empty;

    public IEnumerable<Ad> Ads { get; set; } = new List<Ad>();
}