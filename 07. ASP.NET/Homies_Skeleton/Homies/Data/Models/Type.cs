using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static Homies.Data.DataConstants;

namespace Homies.Data.Models;

public class Type
{
    [Key]
    [Comment("Type Id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(TypeNameMaxLength)]
    [Comment("Type Name")]
    public string Name { get; set; } = null!;
    
    public IEnumerable<Event> Events { get; set; }  = new List<Event>();
}