using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Core.Constants.MessageConstants;
using static HouseRentingSystem.Infrastructure.Data.Constants.DataConstants;

namespace HouseRentingSystem.Core.Models.Agent;

public class BecomeAgentFormModel
{
    [Required(ErrorMessage = RequiredErrorMessage)]
    [StringLength(AgentPhoneNumberMaxLength,
        MinimumLength = AgentPhoneNumberMinLength,
        ErrorMessage = StringFieldLengthErrorMessage)]
    [Display(Name = "Phone Number")]
    [Phone]
    public string PhoneNumber { get; set; } = null!;
}