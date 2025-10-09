using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static SeminarHub.Common.Constants.DataConstants;

namespace SeminarHub.Data.Models;

public class Seminar
{
    [Key]
    [Comment("Seminar Id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(SeminarTopicMaxLength)]
    [Comment("Seminar Topic")]
    public string Topic { get; set; } = null!;

    [Required]
    [MaxLength(SeminarLecturerMaxLength)]
    [Comment("Seminar Lecturer")]
    public string Lecturer { get; set; } = null!;

    [Required]
    [MaxLength(SeminarDetailsMaxLength)]
    [Comment("Seminar Details")]
    public string Details { get; set; } = null!;

    [Required]
    [Comment("Seminar Organizer")]
    public string OrganizerId { get; set; } = null!;

    [ForeignKey(nameof(OrganizerId))]
    public IdentityUser Organizer { get; set; } = null!;

    [Required]
    [Comment("Seminar Date and Time")]
    public DateTime DateAndTime { get; set; }

    [Range(SeminarDurationMinimum, SeminarDurationMaximum)]
    [Comment("Seminar Duration")]
    public int? Duration { get; set; }

    [Required]
    [Comment("Seminar Category")]
    public int CategoryId { get; set; }

    public Category Category { get; set; } = null!;

    public IEnumerable<SeminarParticipant> SeminarParticipants { get; set; } = new List<SeminarParticipant>();
}