using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using static SeminarHub.Data.Constants.DataConstants;

namespace SeminarHub.Data.Models;

public class Seminar
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(SeminarTopicMaxLength)]
    public string Topic { get; set; } = null!;

    [Required]
    [MaxLength(SeminarLecturerMaxLength)]
    public string Lecturer { get; set; } = null!;
    
    [Required]
    [MaxLength(SeminarDetailsMaxLength)]
    public string Details { get; set; } = null!;

    [Required]
    public string OrganizerId { get; set; } = null!;

    [ForeignKey(nameof(OrganizerId))]
    public IdentityUser Organizer { get; set; } = null!;
    
    [Required]
    public DateTime DateAndTime { get; set; }

    public int Duration { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; } = null!;

    public IEnumerable<SeminarParticipant> SeminarsParticipants { get; set; } = new List<SeminarParticipant>();
}