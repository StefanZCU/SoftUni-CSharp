using System.Text.RegularExpressions;
using HouseRentingSystem.Core.Contracts;

namespace HouseRentingSystem.Core.Extensions;

public static class ModelExtensions
{
    public static string GetInformation(this IHouseModel house)
    {
        string info = house.Title.Replace(" ", "-") + "-" + GetAddress(house.Address);
        
        return Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);
    }

    private static string GetAddress(string address)
    {
        address = String.Join("-", address.Split(" ").Take(3));
        return address;
    }
}