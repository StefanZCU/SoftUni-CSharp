using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagonList = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] input = command.Split();

                if (input[0] == "Add")
                {
                    wagonList = GetAddPassengers(wagonList, int.Parse(input[1]));
                }
                else
                {
                    wagonList = FindPlacePassengers(wagonList, int.Parse(input[0]), maxCapacity);
                }
            }

            Console.WriteLine(String.Join(" ", wagonList));
        }

        static List<int> GetAddPassengers(List<int> wagonList, int passengers)
        {
            wagonList.Add(passengers);
            return wagonList;
        }

        static List<int> FindPlacePassengers(List<int> wagonList, int passengersToAdd, int maxCapacity)
        {

            for (int i = 0; i < wagonList.Count; i++)
            {
                if (wagonList[i] + passengersToAdd <= maxCapacity)
                {
                    wagonList[i] = wagonList[i] + passengersToAdd;
                    break;
                }
                else
                {
                    continue;
                }
            }

            return wagonList;
        }
    }
}
