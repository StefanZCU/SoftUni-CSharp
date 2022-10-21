using System;
using System.Linq;
using System.Numerics;

namespace _02._From_Left_to_The_Right
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numLines = int.Parse(Console.ReadLine());

            BigInteger sum1 = 0;
            BigInteger sum2 = 0;

            for (int i = 0; i < numLines; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();

                BigInteger num1 = BigInteger.Parse(input[0]);
                BigInteger num2 = BigInteger.Parse(input[1]);

                if (num1 > num2)
                {
                    for (int j = 0; j < input[0].Length; j++)
                    {
                        sum1 += num1 % 10;
                        num1 /= 10;
                    }

                    Console.WriteLine(Math.Abs((decimal)sum1));
                    sum1 = 0;
                }
                else
                {
                    for (int j = 0; j < input[1].Length; j++)
                    {
                        sum2 += num2 % 10;
                        num2 /= 10;
                    }

                    Console.WriteLine(Math.Abs((decimal)sum2));
                    sum2 = 0;
                }
            }
        }
    }
}
