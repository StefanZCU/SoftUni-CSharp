using System.Text.RegularExpressions;
using HouseRentingSystem.Core.Contracts;

namespace HouseRentingSystem.Core.Extensions;

public static class ModelExtensions 
{
     public static string GetInformation(this IHouseModel house)
     {
          string info =  house.Title.Replace(" ", "-") + GetAddress(house.Address);
          info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

          return info;
     }

     private static string GetAddress(string houseAddress)
     {
          houseAddress = string.Join("-", houseAddress.Split(" ").Take(3));

          return houseAddress;
     }
}