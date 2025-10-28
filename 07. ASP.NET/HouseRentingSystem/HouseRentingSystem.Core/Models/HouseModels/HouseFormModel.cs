using System.ComponentModel.DataAnnotations;
using HouseRentingSystem.Core.Contracts;
using static HouseRentingSystem.Infrastructure.Constants.DataConstants;
using static HouseRentingSystem.Core.Constants.ErrorConstants;

namespace HouseRentingSystem.Core.Models.HouseModels;

public class HouseFormModel :IHouseModel
{
    [Required(ErrorMessage = RequiredFieldError)]
    [StringLength(maximumLength: HouseTitleMaxLength,
        MinimumLength = HouseTitleMinLength,
        ErrorMessage = InvalidFieldLengthError)]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = RequiredFieldError)]
    [StringLength(maximumLength: HouseAddressMaxLength,
        MinimumLength = HouseAddressMinLength,
        ErrorMessage = InvalidFieldLengthError)]
    public string Address { get; set; } = null!;

    [Required(ErrorMessage = RequiredFieldError)]
    [StringLength(maximumLength: HouseDescriptionMaxLength,
        MinimumLength = HouseDescriptionMinLength,
        ErrorMessage = InvalidFieldLengthError)]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = RequiredFieldError)]
    [Display(Name = "Image URL")]
    public string ImageUrl { get; set; } = null!;

    [Required]
    [Range(typeof(decimal),
        HousePricePerMonthMinValue,
        HousePricePerMonthMaxValue,
        ConvertValueInInvariantCulture = true,
        ErrorMessage = InvalidPricePerMonthError)]
    [Display(Name = "Price per month")]
    public decimal PricePerMonth { get; set; }

    [Display(Name = "Category")] public int CategoryId { get; set; }

    public IEnumerable<HouseCategoryServiceModel> Categories { get; set; } = new List<HouseCategoryServiceModel>();
}