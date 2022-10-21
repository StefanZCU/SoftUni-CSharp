using System;

namespace _07._Moving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int widthFreeSpace = int.Parse(Console.ReadLine());
            int lengthFreeSpace = int.Parse(Console.ReadLine());
            int heightFreeSpace = int.Parse(Console.ReadLine());

            int totalFreeSpace = widthFreeSpace * lengthFreeSpace * heightFreeSpace;
            int usedSpace = 0;

            while (totalFreeSpace > 0)
            {
                string command = Console.ReadLine();

                if (command == "Done")
                {
                    totalFreeSpace -= usedSpace;
                    Console.WriteLine($"{totalFreeSpace} Cubic meters left.");
                    break;
                }

                int boxesSpace = int.Parse(command);
                usedSpace += boxesSpace;

                if (usedSpace > totalFreeSpace)
                {
                    usedSpace -= totalFreeSpace;
                    Console.WriteLine($"No more free space! You need {usedSpace} Cubic meters more.");
                    break;
                }
            }
        }
    }
}
