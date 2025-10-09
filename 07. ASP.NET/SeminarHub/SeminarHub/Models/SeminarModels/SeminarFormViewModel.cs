using System.ComponentModel.DataAnnotations;
using SeminarHub.Data.Models;
using SeminarHub.Models.CategoryModels;
using static SeminarHub.Common.Constants.DataConstants;
using static SeminarHub.Common.Constants.ErrorConstants;

namespace SeminarHub.Models.SeminarModels;

public class SeminarFormViewModel
{
    [Required(ErrorMessage = RequiredFieldError)]
    [StringLength(maximumLength: SeminarTopicMaxLength,
        MinimumLength = SeminarTopicMinLength,
        ErrorMessage = FieldLengthError)]
    [Display(Name = "Seminar Topic")]
    public string Topic { get; set; } = null!;

    [Required(ErrorMessage = RequiredFieldError)]
    [StringLength(maximumLength: SeminarLecturerMaxLength,
        MinimumLength = SeminarLecturerMinLength,
        ErrorMessage = FieldLengthError)]
    [Display(Name = "Lecturer")]
    public string Lecturer { get; set; } = null!;

    [Required(ErrorMessage = RequiredFieldError)]
    [StringLength(maximumLength: SeminarDetailsMaxLength,
        MinimumLength = SeminarDetailsMinLength,
        ErrorMessage = FieldLengthError)]
    [Display(Name = "More Info")]
    public string Details { get; set; } = null!;

    [Required(ErrorMessage = RequiredFieldError)]
    [Display(Name = "Date of Seminar")]
    public string DateAndTime { get; set; } = null!;

    [Range(SeminarDurationMinimum, SeminarDurationMaximum, ErrorMessage = DurationFieldLengthError)]
    [Display(Name = "Duration")]
    public int? Duration { get; set; }

    [Required(ErrorMessage = RequiredFieldError)]
    [Display(Name = "Select Category")]
    public int CategoryId { get; set; }

    public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
}