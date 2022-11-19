using System;
using System.Numerics;

namespace _7._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int triangleLength = int.Parse(Console.ReadLine());

            BigInteger[][] triangle = new BigInteger[triangleLength][];

            int size = 3;

            for (int i = 0; i < triangleLength; i++)
            {
                triangle[i] = new BigInteger[size];
                size++;
            }

            triangle[0][0] = 0;
            triangle[0][1] = 1;
            triangle[0][2] = 0;

            for (int i = 1; i < triangleLength; i++)
            {
                for (int j = 0; j < triangle[i].Length; j++)
                {
                    if (j == 0 || j + 1 == triangle[i].Length)
                    {
                        triangle[i][j] = 0;
                    }
                    else
                    {
                        triangle[i][j] = triangle[i -1][j - 1] + triangle[i - 1][j];
                    }
                }
            }

            for (int i = 0; i < triangleLength; i++)
            {
                for (int k = 0; k < triangle[i].Length; k++)
                {
                    if (triangle[i][k] != 0)
                    {
                        Console.Write($"{triangle[i][k]} ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
