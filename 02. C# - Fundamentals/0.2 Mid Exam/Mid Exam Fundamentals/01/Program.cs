using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _01_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numDaysAdventure = int.Parse(Console.ReadLine());
            int numPlayers = int.Parse(Console.ReadLine());
            decimal groupEnergy = decimal.Parse(Console.ReadLine());
            decimal waterPerDayPerson = decimal.Parse(Console.ReadLine());
            decimal foodPerDayPerson = decimal.Parse(Console.ReadLine());

            decimal totalWater = numDaysAdventure * numPlayers * waterPerDayPerson;
            decimal totalFood = numDaysAdventure * numPlayers * foodPerDayPerson;
            bool flag = true;

            for (int i = 1; i <= numDaysAdventure; i++)
            {
                decimal energyLossPerDay = decimal.Parse(Console.ReadLine());

                groupEnergy -= energyLossPerDay;

                if (groupEnergy <= 0)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {totalFood:F2} food and {totalWater:F2} water.");
                    flag = false;
                    break;
                }

                if (i % 2 == 0)
                {
                    totalWater = totalWater - (totalWater * 0.3m);
                    groupEnergy = groupEnergy + (groupEnergy * 0.05m);
                }

                if (i % 3 == 0)
                {
                    totalFood = totalFood - (totalFood / (decimal)numPlayers);
                    groupEnergy = groupEnergy + (groupEnergy * 0.1m);
                }
            }

            if (flag)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {groupEnergy:F2} energy!");
            }
        }
    }
}