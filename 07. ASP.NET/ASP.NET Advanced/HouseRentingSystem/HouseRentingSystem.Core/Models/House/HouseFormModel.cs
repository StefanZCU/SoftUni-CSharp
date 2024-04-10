using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Core.Constants.MessageConstants;
using static HouseRentingSystem.Infrastructure.Data.Constants.DataConstants;

namespace HouseRentingSystem.Core.Models.House;

public class HouseFormModel
{
    [Required(ErrorMessage = RequiredErrorMessage)]
    [StringLength(HouseTitleMaxLength, MinimumLength = HouseTitleMinLength, ErrorMessage = StringFieldLengthErrorMessage)]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = RequiredErrorMessage)]
    [StringLength(HouseAddressMaxLength, MinimumLength = HouseAddressMinLength, ErrorMessage = StringFieldLengthErrorMessage)]
    public string Address { get; set; } = null!;

    [Required(ErrorMessage = RequiredErrorMessage)]
    [StringLength(HouseDescriptionMaxLength, MinimumLength = HouseDescriptionMinLength, ErrorMessage = StringFieldLengthErrorMessage)]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = RequiredErrorMessage)]
    [Display(Name = "Image URL")]
    public string ImageUrl { get; set; } = null!;

    [Required(ErrorMessage = RequiredErrorMessage)]
    [Range(typeof(decimal), HousePricePerMonthMinValue, HousePricePerMonthMaxValue, ErrorMessage = PricePerMonthErrorMessage)]
    [Display(Name = "Price Per Month")]
    public decimal PricePerMonth { get; set; }

    [Display(Name = "Category")]
    public int CategoryId { get; set; }

    public IEnumerable<HouseCategoryServiceModel> Categories { get; set; } = new List<HouseCategoryServiceModel>();


}