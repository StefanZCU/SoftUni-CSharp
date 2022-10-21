using System;

namespace _07._Hotel_Room
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int numberOfDays = int.Parse(Console.ReadLine());


            switch (month)
            {
                case "May":
                case "October":
                    double studioPerNightMO = 50.0;
                    double studioPriceMO = studioPerNightMO * numberOfDays;
                    double apartmentPerNightMO = 65.0;
                    double apartmentPriceMO = apartmentPerNightMO * numberOfDays;

                    if ((numberOfDays > 7) && (numberOfDays < 14))
                    {
                        double discountStudioPrice = studioPriceMO - (studioPriceMO * 0.05);
                        Console.WriteLine($"Apartment: {apartmentPriceMO:F2} lv.");
                        Console.WriteLine($"Studio: {discountStudioPrice:F2} lv.");
                    }
                    else if (numberOfDays > 14)
                    {
                        double discountStudioPrice = studioPriceMO - (studioPriceMO * 0.3);
                        double discountApartmentPrice = apartmentPriceMO - (apartmentPriceMO * 0.1);

                        Console.WriteLine($"Apartment: {discountApartmentPrice:F2} lv.");
                        Console.WriteLine($"Studio: {discountStudioPrice:F2} lv.");
                    }
                    else
                    {
                        Console.WriteLine($"Apartment: {apartmentPriceMO:F2} lv.");
                        Console.WriteLine($"Studio: {studioPriceMO:F2} lv.");
                    }


                    break;

                case "June":
                case "September":
                    double studioPerNightJS = 75.2;
                    double studioPriceJS = studioPerNightJS * numberOfDays;
                    double apartmentPerNightJS = 68.7;
                    double apartmentPriceJS = apartmentPerNightJS * numberOfDays;

                    if (numberOfDays > 14)
                    {
                        double discountStudioPrice = studioPriceJS - (studioPriceJS * 0.2);
                        double discountApartmentPrice = apartmentPriceJS - (apartmentPriceJS * 0.1);
                        Console.WriteLine($"Apartment: {discountApartmentPrice:F2} lv.");
                        Console.WriteLine($"Studio: {discountStudioPrice:F2} lv.");
                    }

                    else
                    {
                        Console.WriteLine($"Apartment: {apartmentPriceJS:F2} lv.");
                        Console.WriteLine($"Studio: {studioPriceJS:F2} lv.");
                    }
                    break;
                case "July":
                case "August":
                    double studioPerNightJA = 76.0;
                    double studioPriceJA = studioPerNightJA * numberOfDays;
                    double apartmentPerNightJA = 77.0;
                    double apartmentPriceJA = apartmentPerNightJA * numberOfDays;
                    if (numberOfDays > 14)
                    {

                        double discountApartmentPrice = apartmentPriceJA - (apartmentPriceJA * 0.1);
                        Console.WriteLine($"Apartment: {discountApartmentPrice:F2} lv.");
                        Console.WriteLine($"Studio: {studioPriceJA:F2} lv.");
                    }
                    else
                    {
                        Console.WriteLine($"Apartment: {apartmentPriceJA:F2} lv.");
                        Console.WriteLine($"Studio: {studioPriceJA:F2} lv.");
                    }

                    break;

                default:
                    break;
            }
        }
    }
}
