using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SeminarHub.Data.Models;

public class SeminarParticipant
{
    [Required]
    [Comment("Seminar Id")]
    public int SeminarId { get; set; }

    [ForeignKey(nameof(SeminarId))]
    public Seminar Seminar { get; set; } = null!;

    [Required]
    [Comment("Participant Id")]
    public string ParticipantId { get; set; } = null!;

    [ForeignKey(nameof(ParticipantId))]
    public IdentityUser Participant { get; set; } = null!;
}