using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static SeminarHub.Common.Constants.DataConstants;

namespace SeminarHub.Data.Models;

public class Category
{
    [Key]
    [Comment("Category Id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(CategoryNameMaxLength)]
    [Comment("Category Name")]
    public string Name { get; set; } = null!;

    public IEnumerable<Seminar> Seminars { get; set; } = new List<Seminar>();
}