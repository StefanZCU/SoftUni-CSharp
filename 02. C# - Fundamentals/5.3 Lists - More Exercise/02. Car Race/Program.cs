using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Car_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> raceTrack = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();


            decimal leftSum = 0.0m;
            decimal rightSum = 0.0m;

            decimal indexLeft = Math.Floor(raceTrack.Count / 2.0m) - 1m;
            decimal indexRight = Math.Ceiling(raceTrack.Count / 2.0m);
            decimal middle = (raceTrack.Count - 1m) / 2m;

            for (int i = 0; i < middle; i++)
            {
                if (i <= indexLeft && raceTrack[i] == 0)
                {
                    leftSum *= 0.8m;
                }
                else if (i <= indexLeft)
                {
                    leftSum += raceTrack[i];
                }
            }

            for (int j = raceTrack.Count - 1; j > middle; j--)
            {
                if (j >= indexRight && raceTrack[j] == 0)
                {
                    rightSum *= 0.8m;
                }
                else if (j >= indexRight)
                {
                    rightSum += raceTrack[j];
                }
            }

            if (leftSum > rightSum)
            {
                Console.WriteLine($"The winner is right with total time: {rightSum.ToString("0.####")}");
            }
            else
            {
                Console.WriteLine($"The winner is left with total time: {leftSum.ToString("0.####")}");
            }
        }
    }
}
