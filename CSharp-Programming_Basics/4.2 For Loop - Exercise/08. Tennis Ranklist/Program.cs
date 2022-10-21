using System;

namespace _08._Tennis_Ranklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfTournaments = int.Parse(Console.ReadLine());
            int initialPoints = int.Parse(Console.ReadLine());

            int sum = 0;
            double wins = 0.0;

            for (int i = 1; i <= numberOfTournaments; i++)
            {
                string tournament = Console.ReadLine();

                if (tournament == "W")
                {
                    sum += 2000;
                    wins++;
                }
                else if (tournament == "F")
                {
                    sum += 1200;

                }
                else if (tournament == "SF")
                {
                    sum += 720;
                }
            }

            double average = sum / numberOfTournaments;
            int totalPoints = initialPoints + sum;

            double totalWinPercentage = (wins / numberOfTournaments) * 100;

            Console.WriteLine($"Final points: {totalPoints}");
            Console.WriteLine($"Average points: {Math.Floor(average)}");
            Console.WriteLine($"{totalWinPercentage:F2}%");
        }
    }
}
