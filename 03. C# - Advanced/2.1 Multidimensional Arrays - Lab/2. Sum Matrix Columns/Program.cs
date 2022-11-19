using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowAndCols = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int[,] matrix = new int[rowAndCols[0], rowAndCols[1]];
            int[] colSum = new int[rowAndCols[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] cols = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = cols[j];
                    colSum[j] += cols[j];
                }
            }

            foreach (var sum in colSum)
            {
                Console.WriteLine(sum);
            }
        }
    }
}
