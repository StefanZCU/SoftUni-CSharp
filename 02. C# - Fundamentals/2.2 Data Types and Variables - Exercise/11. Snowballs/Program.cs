using System;
using System.Numerics;

namespace _11._Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            BigInteger bestSnowball = 0;
            int bestSnow = 0;
            int bestTime = 0;
            int bestQuality = 0;

            for (int i = 1; i <= num; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger snowBall = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality);

                if (snowBall > bestSnowball)
                {
                    bestSnowball = snowBall;
                    bestSnow = snowballSnow;
                    bestTime = snowballTime;
                    bestQuality = snowballQuality;
                }

            }

            Console.WriteLine($"{bestSnow} : {bestTime} = {bestSnowball} ({bestQuality})");
        }
    }
}