using System.Linq;
using System;

namespace _09._Kamino_Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //int seqLength = int.Parse(Console.ReadLine());



            //while (true)
            //{
            //    string sequence = Console.ReadLine();

            //    if (sequence == "Clone them!")
            //    {

            //        break;
            //    }

            //    int[] numbers = sequence.Split('!').Select(int.Parse).ToArray();

            //    for (int i = 0; i < numbers.Length; i++)
            //    {
            //        for (int j = 0; j < numbers.Length; j++)
            //        {

            //        }
            //    }
            //}

            int length = int.Parse(Console.ReadLine());

            int samples = 0;
            int bestSample = 0;
            int bestCount = 0;
            int bestSum = 0;
            int smalerIndex = -1;
            int[] bestDNASample = new int[length];

            string command = Console.ReadLine();

            while (command != "Clone them!")
            {
                int[] dna = command
                    .Split("!", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                samples++;

                int currentCount = 0;
                int counter = 0;
                int sum = 0;
                int currentIndex = int.MinValue;
                bool isBestDNA = false;

                for (int i = 0; i < length; i++)
                {
                    if (dna[i] == 0)
                    {
                        counter = 0;
                        continue;
                    }
                    counter++;

                    if (counter > currentCount)
                    {
                        currentCount = counter;
                        currentIndex = i - currentCount + 1;
                    }
                }

                sum = dna.Sum();

                if (currentCount > bestCount)
                {
                    isBestDNA = true;
                }
                else if (currentCount == bestCount)
                {
                    if (currentIndex < smalerIndex)
                    {
                        isBestDNA = true;
                    }
                    else if (currentIndex == smalerIndex)
                    {
                        if (sum > bestSum)
                        {
                            isBestDNA = true;
                        }
                    }
                }

                if (isBestDNA)
                {
                    bestCount = currentCount;
                    smalerIndex = currentIndex;
                    bestSum = sum;
                    bestSample = samples;
                    bestDNASample = dna;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestSample} with sum: {bestSum}.");
            Console.Write(string.Join(" ", bestDNASample));


        }
    }
}
