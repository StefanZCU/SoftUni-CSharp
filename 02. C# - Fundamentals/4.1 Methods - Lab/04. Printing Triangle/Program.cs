using System;

namespace _04._Printing_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i <= num; i++)
            {
                PrintLine(1, i);
                
            }

            for (int i = num - 1; i >= 1; i--)
            {
                PrintLine(1, i);
            }
        }

        private static void PrintLine(int start, int end)
        {
            for (int j = start; j <= end; j++)
            {
                Console.Write(j + " ");
            }

            Console.WriteLine();
        }
    }
}
