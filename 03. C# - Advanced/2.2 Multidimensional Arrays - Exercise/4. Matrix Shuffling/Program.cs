using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowAndColsLength = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rowSize = rowAndColsLength[0];
            int colSize = rowAndColsLength[1];

            string[,] matrix = new string[rowSize, colSize];

            for (int i = 0; i < rowSize; i++)
            {
                string[] currCol = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < colSize; j++)
                {
                    matrix[i, j] = currCol[j];
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (InputChecker(input, rowSize, colSize))
                {
                    int row1 = int.Parse(input[1]);
                    int col1 = int.Parse(input[2]);
                    int row2 = int.Parse(input[3]);
                    int col2 = int.Parse(input[4]);

                    (matrix[row1, col1], matrix[row2, col2]) = (matrix[row2, col2], matrix[row1, col1]);

                    for (int i = 0; i < rowSize; i++)
                    {
                        for (int j = 0; j < colSize; j++)
                        {
                            Console.Write($"{matrix[i, j]} ");
                        }

                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        static bool InputChecker(string[] input, int rowSize, int colSize)
        {
            if (input[0] == "swap" && input.Length == 5)
            {
                int[] indexes =
                {
                    int.Parse(input[1]),
                    int.Parse(input[2]),
                    int.Parse(input[3]),
                    int.Parse(input[4])
                };

                if (IndexChecker(indexes, rowSize, colSize))
                {
                    return true;
                }
            }

            return false;
        }

        static bool IndexChecker(int[] indexes, int rowSize, int colSize)
        {
            if (indexes[0] >= 0 && indexes[1] >= 0 && indexes[2] >= 0 && indexes[3] >= 0
                && indexes[0] < rowSize && indexes[1] < colSize && indexes[2] < rowSize && indexes[3] < colSize)
            {
                return true;
            }
            return false;
        }
    }
}
