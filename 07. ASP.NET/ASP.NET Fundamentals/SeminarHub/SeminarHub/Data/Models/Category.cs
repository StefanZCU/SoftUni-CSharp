using System.ComponentModel.DataAnnotations;
using static SeminarHub.Data.Constants.DataConstants;

namespace SeminarHub.Data.Models;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(CategoryNameMaxLength)]
    public string Name { get; set; } = null!;

    public IEnumerable<Seminar> Seminars { get; set; } = new List<Seminar>();
}