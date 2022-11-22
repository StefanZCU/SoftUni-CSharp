using System;
using System.Collections.Generic;

namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> citiesPerCountryPerCont =
                new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!citiesPerCountryPerCont.ContainsKey(continent))
                {
                    citiesPerCountryPerCont.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!citiesPerCountryPerCont[continent].ContainsKey(country))
                {
                    citiesPerCountryPerCont[continent].Add(country, new List<string>());
                }

                citiesPerCountryPerCont[continent][country].Add(city);
            }

            foreach (var continent in citiesPerCountryPerCont)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
