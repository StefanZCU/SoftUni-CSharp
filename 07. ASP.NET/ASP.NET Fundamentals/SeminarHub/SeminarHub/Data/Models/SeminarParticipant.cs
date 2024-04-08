using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SeminarHub.Data.Models;

public class SeminarParticipant
{
    [Required]
    public int SeminarId { get; set; }

    [ForeignKey(nameof(SeminarId))]
    public Seminar Seminar { get; set; } = null!;

    [Required]
    public string ParticipantId { get; set; } = null!;

    [ForeignKey(nameof(ParticipantId))]
    public IdentityUser Participant { get; set; } = null!;
}