using System;

namespace _01._World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string initialStops = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Travel")
            {
                string[] input = command.Split(":");

                if (input[0] == "Add Stop")
                {
                    int index = int.Parse(input[1]);
                    string newString = input[2];

                    if (index >= 0 && index < initialStops.Length)
                    {
                        initialStops = initialStops.Insert(index, newString);
                    }

                    Console.WriteLine(initialStops);
                }
                else if (input[0] == "Remove Stop")
                {
                    int startIndex = int.Parse(input[1]);
                    int lastIndex = int.Parse(input[2]);

                    if (startIndex >= 0 && lastIndex >= startIndex && lastIndex < initialStops.Length)
                    {
                        initialStops = initialStops.Remove(startIndex, lastIndex - startIndex + 1);
                    }
                    
                    Console.WriteLine(initialStops);

                }
                else if (input[0] == "Switch")
                {
                    string oldString = input[1];
                    string newString = input[2];

                    if (initialStops.Contains(oldString))
                    {
                        initialStops = initialStops.Replace(oldString, newString);
                    }

                    Console.WriteLine(initialStops);
                }
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {initialStops}");
        }
    }
}
