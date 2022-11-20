using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numRows = int.Parse(Console.ReadLine());

            int[][] jaggedMatrix = new int[numRows][];

            for (int i = 0; i < numRows; i++)
            {
                int[] currCol = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                jaggedMatrix[i] = new int[currCol.Length];

                for (int j = 0; j < currCol.Length; j++)
                {
                    jaggedMatrix[i][j] = currCol[j];
                }
            }

            for (int i = 0; i < numRows - 1; i++)
            {
                if (jaggedMatrix[i].Length == jaggedMatrix[i + 1].Length)
                {
                    for (int j = 0; j < jaggedMatrix[i].Length; j++)
                    {
                        jaggedMatrix[i][j] *= 2;
                        jaggedMatrix[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < jaggedMatrix[i].Length; j++)
                    {
                        jaggedMatrix[i][j] /= 2;
                    }

                    for (int j = 0; j < jaggedMatrix[i + 1].Length; j++)
                    {
                        jaggedMatrix[i + 1][j] /= 2;
                    }
                }
            }


            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);
                int value = int.Parse(input[3]);

                if (input[0] == "Add" && row >= 0 && row < numRows && jaggedMatrix[row].Length > col && col >= 0)
                {
                    jaggedMatrix[row][col] += value;
                }
                else if (input[0] == "Subtract" && row >= 0 && row < numRows && jaggedMatrix[row].Length > col && col >= 0)
                {
                    jaggedMatrix[row][col] -= value;
                }

            }

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < jaggedMatrix[i].Length; j++)
                {
                    Console.Write($"{jaggedMatrix[i][j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
