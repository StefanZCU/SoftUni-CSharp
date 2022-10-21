using System;

namespace _04._Sum_of_Two_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int beginningInterval = int.Parse(Console.ReadLine());
            int endInterval = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            int sumCounter = 0;
            int foundSum = 0;
            int noSum = 0;

            for (int i = beginningInterval; i <= endInterval; i++)
            {
                for (int j = beginningInterval; j <= endInterval; j++)
                {
                    sumCounter++;

                    if (i + j == magicNumber)
                    {
                        foundSum++;
                        Console.WriteLine($"Combination N:{sumCounter} ({i} + {j} = {magicNumber})");
                        break;
                    }

                    if (i + j != magicNumber)
                    {
                        noSum++;
                    }
                }

                if (foundSum > 0)
                {
                    break;
                }
            }

            if ((noSum != 0) && (foundSum == 0))
            {
                Console.WriteLine($"{noSum} combinations - neither equals {magicNumber}");
            }

        }
    }
}
