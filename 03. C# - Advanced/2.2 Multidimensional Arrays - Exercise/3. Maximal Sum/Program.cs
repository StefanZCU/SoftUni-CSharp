using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowAndColsLength = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            if (rowAndColsLength[0] >= 3 && rowAndColsLength[1] >= 3) 
            {

                int[,] matrix = new int[rowAndColsLength[0], rowAndColsLength[1]];

                for (int i = 0; i < rowAndColsLength[0]; i++)
                {
                    int[] col = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                    for (int j = 0; j < rowAndColsLength[1]; j++)
                    {
                        matrix[i, j] = col[j];
                    }
                }

                int highestValue = int.MinValue;
                int startIndexRow = 0;
                int startIndexCol = 0;
                int endIndexRow = 0;
                int endIndexCol = 0;

                for (int i = 0; i < rowAndColsLength[0] - 2; i++)
                {
                    for (int j = 0; j < rowAndColsLength[1] - 2; j++)
                    {
                        if (matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2] + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2] > highestValue)
                        {
                            highestValue = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] + matrix[i + 1, j] +
                                           matrix[i + 1, j + 1] + matrix[i + 1, j + 2] + matrix[i + 2, j] +
                                           matrix[i + 2, j + 1] + matrix[i + 2, j + 2];

                            startIndexRow = i;
                            startIndexCol = j;
                            endIndexCol = j + 2;
                            endIndexRow = i + 2;
                        }
                    }
                }

                if (highestValue == int.MinValue)
                {
                    Console.WriteLine($"Sum = 0");
                }
                else
                {
                    Console.WriteLine($"Sum = {highestValue}");
                }

                for (int i = startIndexRow; i <= endIndexRow; i++)
                {
                    for (int j = startIndexCol; j <= endIndexCol; j++)
                    {
                        Console.Write($"{matrix[i, j]} ");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
