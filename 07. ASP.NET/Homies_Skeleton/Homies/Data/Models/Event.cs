using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static Homies.Data.DataConstants;

namespace Homies.Data.Models;

public class Event
{
    [Key]
    [Comment("Event Id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(EventNameMaxLength)]
    [Comment("Event Name")]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(EventDescriptionMaxLength)]
    [Comment("Event Description")]
    public string Description { get; set; } = null!;

    [Required]
    [Comment("Event Organiser")]
    public string OrganiserId { get; set; } = null!;

    [ForeignKey(nameof(OrganiserId))]
    public IdentityUser Organiser { get; set; } = null!;

    [Required]
    [Comment("Event Creation Date")]
    public DateTime CreatedOn { get; set; }

    [Required]
    [Comment("Event Start Date")]
    public DateTime Start { get; set; }

    [Required]
    [Comment("Event End Date")]
    public DateTime End { get; set; }

    [Required]
    [Comment("Event Type")]
    public int TypeId { get; set; }
    
    [ForeignKey(nameof(TypeId))]
    public Type Type { get; set; }

    [Comment("Event Participants")]
    public IList<EventParticipant> EventParticipants { get; set; }  = new List<EventParticipant>();

}