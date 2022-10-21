using System;

namespace _02._Summer_Outfit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double temperature = double.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();
            string outfit = "";
            string shoes = "";

            if ((temperature >= 10) && (temperature <= 18))
            {
                if (timeOfDay == "Morning")
                {
                    outfit = "Sweatshirt";
                    shoes = "Sneakers";
                    Console.WriteLine($"It's {temperature} degrees, get your {outfit} and {shoes}.");
                }
                else if ((timeOfDay == "Afternoon") || (timeOfDay == "Evening"))
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                    Console.WriteLine($"It's {temperature} degrees, get your {outfit} and {shoes}.");
                }
            }
            else if ((temperature > 18) && (temperature <= 24))
            {
                if ((timeOfDay == "Morning") || (timeOfDay == "Evening"))
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                    Console.WriteLine($"It's {temperature} degrees, get your {outfit} and {shoes}.");
                }
                else if (timeOfDay == "Afternoon")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                    Console.WriteLine($"It's {temperature} degrees, get your {outfit} and {shoes}.");
                }
            }
            else if (temperature >= 25)
            {
                if (timeOfDay == "Morning")
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                    Console.WriteLine($"It's {temperature} degrees, get your {outfit} and {shoes}.");
                }
                else if (timeOfDay == "Afternoon")
                {
                    outfit = "Swim Suit";
                    shoes = "Barefoot";
                    Console.WriteLine($"It's {temperature} degrees, get your {outfit} and {shoes}.");
                }
                else if (timeOfDay == "Evening")
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                    Console.WriteLine($"It's {temperature} degrees, get your {outfit} and {shoes}.");
                }
            }
        }
    }
}
