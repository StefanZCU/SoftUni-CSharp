using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GameZoneUpdated.Infrastructure.Data.Models;

[Comment("GamerGame table")]
public class GamerGame
{
    [Required]
    [Comment("Game Identifier")]
    public required int GameId { get; set; }

    [ForeignKey(nameof(GameId))]
    public Game Game { get; set; } = null!;

    [Required]
    [Comment("Gamer Identifier")]
    public required string GamerId { get; set; }

    [ForeignKey(nameof(GamerId))]
    public IdentityUser Gamer { get; set; } = null!;
}