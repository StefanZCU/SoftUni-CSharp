using System;
using System.Collections.Generic;

namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carPlates = new HashSet<string>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] input = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "IN")
                {
                    if (!carPlates.Contains(input[1]))
                    {
                        carPlates.Add(input[1]);
                    }
                }
                else
                {
                    if (carPlates.Contains(input[1]))
                    {
                        carPlates.Remove(input[1]);
                    }
                }
            }

            if (carPlates.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var plate in carPlates)
                {
                    Console.WriteLine(plate);
                }
            }
        }
    }
}
