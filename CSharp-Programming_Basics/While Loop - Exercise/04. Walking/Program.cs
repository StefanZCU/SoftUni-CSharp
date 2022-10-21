using System;

namespace _04._Walking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int stepsSum = 0;

            while (true)
            {
                string steps = Console.ReadLine();

                if (steps == "Going home")
                {
                    steps = Console.ReadLine();
                    int numberSteps = int.Parse(steps);
                    stepsSum += numberSteps;

                    if (stepsSum < 10000)
                    {
                        stepsSum = 10000 - stepsSum;
                        Console.WriteLine($"{stepsSum} more steps to reach goal.");
                        break;
                    }
                    else
                    {
                        stepsSum -= 10000;
                        Console.WriteLine("Goal reached! Good job!");
                        Console.WriteLine($"{stepsSum} steps over the goal!");
                        break;
                    }

                }

                int numberSteps2 = int.Parse(steps);
                stepsSum += numberSteps2;

                if (stepsSum >= 10000)
                {
                    stepsSum -= 10000;
                    Console.WriteLine("Goal reached! Good job!");
                    Console.WriteLine($"{stepsSum} steps over the goal!");
                    break;
                }
            }
        }
    }
}
