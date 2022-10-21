using System;

namespace _02._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int rows = int.Parse(Console.ReadLine()), val = 1, i, j;

            for (i = 0; i < rows; i++)
            {
                for (j = 0; j <= i; j++)
                {
                    if (j == 0 || i == 0)
                        val = 1;
                    else
                        val = val * (i - j + 1) / j;
                    Console.Write(val + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
