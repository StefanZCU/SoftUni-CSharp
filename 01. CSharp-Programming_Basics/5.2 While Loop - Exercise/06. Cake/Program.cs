using System;

namespace _06._Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int widthCake = int.Parse(Console.ReadLine());
            int lengthCake = int.Parse(Console.ReadLine());

            int cakeSize = widthCake * lengthCake;
            int piecesTaken = cakeSize;

            while (cakeSize > 0)
            {
                string command = Console.ReadLine();

                if (command == "STOP")
                {
                    Console.WriteLine($"{Math.Abs(piecesTaken)} pieces are left.");
                    break;
                }

                int piecesTakenCommand = int.Parse(command);
                piecesTaken -= piecesTakenCommand;

                if (piecesTaken <= 0)
                {
                    Console.WriteLine($"No more cake left! You need {Math.Abs(piecesTaken)} pieces more.");
                    break;
                }
            }
        }
    }
}
