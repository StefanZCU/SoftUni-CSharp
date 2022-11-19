using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _2._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowAndCol = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            char[,] matrix = new char[rowAndCol[0], rowAndCol[1]];

            for (int i = 0; i < rowAndCol[0]; i++)
            {
                char[] currCol = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int j = 0; j < rowAndCol[1]; j++)
                {
                    matrix[i, j] = currCol[j];
                }
            }

            int foundEqual = 0;

            for (int i = 0; i < rowAndCol[0] - 1; i++)
            {
                for (int j = 0; j < rowAndCol[1] - 1; j++)
                {
                    char currentChar = matrix[i, j];

                    if (matrix[i + 1, j] == currentChar && matrix[i, j + 1] == currentChar && matrix[i + 1, j + 1] == currentChar)
                    {
                        foundEqual++;
                    }
                }
            }

            Console.WriteLine(foundEqual);
        }
    }
}