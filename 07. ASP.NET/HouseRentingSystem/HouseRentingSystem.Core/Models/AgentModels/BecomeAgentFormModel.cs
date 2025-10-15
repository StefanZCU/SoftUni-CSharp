using System.ComponentModel.DataAnnotations;
using HouseRentingSystem.Infrastructure.Constants;
using static HouseRentingSystem.Core.Constants.ErrorConstants;

namespace HouseRentingSystem.Core.Models.AgentModels;
using static DataConstants;

public class BecomeAgentFormModel
{
    [Required(ErrorMessage = RequiredFieldError)]
    [StringLength(
        maximumLength:AgentPhoneNumberMaxLength,
        MinimumLength = AgentPhoneNumberMinLength,
        ErrorMessage = InvalidFieldLengthError)]
    [Display(Name = "Phone Number")]
    [Phone]
    public string PhoneNumber { get; set; } = null!;
}