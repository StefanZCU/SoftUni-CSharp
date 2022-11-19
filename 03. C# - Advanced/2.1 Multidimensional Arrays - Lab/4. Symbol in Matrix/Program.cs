using System;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            char[,] matrix = new char[num, num];

            for (int i = 0; i < num; i++)
            {
                string wordLine = Console.ReadLine();
                char[] col = wordLine.ToCharArray();

                for (int j = 0; j < num; j++)
                {
                    matrix[i, j] = col[j];
                }
            }

            char symbol = char.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    if (matrix[i, j] == symbol)
                    {
                        Console.WriteLine($"({i}, {j})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}
