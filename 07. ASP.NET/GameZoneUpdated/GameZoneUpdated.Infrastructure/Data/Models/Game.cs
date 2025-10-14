using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static GameZoneUpdated.Infrastructure.Constants.DataConstants;

namespace GameZoneUpdated.Infrastructure.Data.Models;

[Comment("Games table")]
public class Game
{
    [Key]
    [Comment("Game Identifier")]
    public int Id { get; set; }

    [Required]
    [MaxLength(GameTitleMaxLength)]
    [Comment("Game Title")]
    public required string Title { get; set; }

    [Required]
    [MaxLength(GameDescriptionMaxLength)]
    [Comment("Game Description")]
    public required string Description { get; set; }

    [Comment("Game Image Url")]
    public string? ImageUrl { get; set; }

    [Required]
    [Comment("Game Publisher Identifier")]
    public required string PublisherId { get; set; }

    [ForeignKey(nameof(PublisherId))]
    public IdentityUser Publisher { get; set; } = null!;

    [Required]
    [Comment("Game Release Date")]
    public required DateTime ReleasedOn { get; set; }

    [Required]
    [Comment("Game Genre Identifier")]
    public required int GenreId { get; set; }

    [ForeignKey(nameof(GenreId))]
    public Genre Genre { get; set; } = null!;

    [Comment("Gamer per Games")]
    public IEnumerable<GamerGame> GamersGames { get; set; } = new List<GamerGame>();
}