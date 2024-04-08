using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SeminarHub.Models.Category;
using static SeminarHub.Data.Constants.ErrorConstants;
using static SeminarHub.Data.Constants.DataConstants;

namespace SeminarHub.Models.Seminar;

public class SeminarFormModel
{
    [Required(ErrorMessage = RequiredFieldError)]
    [StringLength(SeminarTopicMaxLength, MinimumLength = SeminarTopicMinLength,
        ErrorMessage = FieldLengthErrorString)]
    public string Topic { get; set; } = null!;

    [Required(ErrorMessage = RequiredFieldError)]
    [StringLength(SeminarLecturerMaxLength, MinimumLength = SeminarLecturerMinLength,
        ErrorMessage = FieldLengthErrorString)]
    public string Lecturer { get; set; } = null!;

    [Required(ErrorMessage = RequiredFieldError)]
    [StringLength(SeminarDetailsMaxLength, MinimumLength = SeminarDetailsMinLength,
        ErrorMessage = FieldLengthErrorString)]
    public string Details { get; set; } = null!;

    [Required(ErrorMessage = RequiredFieldError)]
    [DisplayName("Date")]
    public string DateAndTime { get; set; } = null!;

    [Range(SeminarDurationMin, SeminarDurationMax, ErrorMessage = FieldLengthErrorNumber)]
    public int Duration { get; set; }

    [Required(ErrorMessage = RequiredFieldError)]
    [DisplayName("Category")]
    public int CategoryId { get; set; }

    public IEnumerable<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
}