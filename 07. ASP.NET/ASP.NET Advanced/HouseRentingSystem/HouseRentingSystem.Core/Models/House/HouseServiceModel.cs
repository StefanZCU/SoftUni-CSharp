using System.ComponentModel.DataAnnotations;
using HouseRentingSystem.Core.Contracts;
using static HouseRentingSystem.Core.Constants.MessageConstants;
using static HouseRentingSystem.Infrastructure.Constants.DataConstants;

namespace HouseRentingSystem.Core.Models.House;

public class HouseServiceModel : IHouseModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = RequiredErrorMessage)]
    [StringLength(HouseTitleMaxLength, MinimumLength = HouseTitleMinLength, ErrorMessage = LengthMessage)]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = RequiredErrorMessage)]
    [StringLength(HouseAddressMaxLength, MinimumLength = HouseAddressMinLength, ErrorMessage = LengthMessage)]
    public string Address { get; set; } = null!;

    [Required(ErrorMessage = RequiredErrorMessage)]
    [Display(Name = "Image URL")]
    public string ImageUrl { get; set; } = null!;

    [Required(ErrorMessage = RequiredErrorMessage)]
    [Range(typeof(decimal), HousePricePerMonthMinLength, HousePricePerMonthMaxLength,
        ConvertValueInInvariantCulture = true,
        ErrorMessage = "The field {0} must be between {1} and {2}")]
    [Display(Name = "Price per Month")]
    public decimal PricePerMonth { get; set; }

    [Display(Name = "Is Rented")]
    public bool IsRented { get; set; }
}