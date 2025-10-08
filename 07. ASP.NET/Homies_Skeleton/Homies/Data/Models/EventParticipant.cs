using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Homies.Data.Models;

public class EventParticipant
{
    [Required]
    [Comment("Helper Id")]
    public string HelperId { get; set; } = null!;

    [ForeignKey(nameof(HelperId))]
    public IdentityUser Helper { get; set; } = null!;

    [Required]
    [Comment("Event Id")]
    public int EventId { get; set; }

    [ForeignKey(nameof(EventId))]
    public Event Event { get; set; } = null!;
}