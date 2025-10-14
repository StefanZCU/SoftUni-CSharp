using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static GameZoneUpdated.Infrastructure.Constants.DataConstants;

namespace GameZoneUpdated.Infrastructure.Data.Models;

[Comment("Genre table")]
public class Genre
{
    [Key]
    [Comment("Genre Identifier")]
    public int Id { get; set; }

    [Required]
    [MaxLength(GenreNameMaxLength)]
    [Comment("Genre Name")]
    public required string Name { get; set; }
    
    [Comment("Games per Genre")]
    public IEnumerable<Game> Games { get; set; } = new List<Game>();
}