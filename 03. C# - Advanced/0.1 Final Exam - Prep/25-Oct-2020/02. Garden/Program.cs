using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02._Garden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[,] matrix = new int[sizeMatrix[0], sizeMatrix[1]];

            List<string> plantedFlowersCoords = new List<string>();

            StringBuilder sb = new StringBuilder();

            string command;
            while ((command = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] coords = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                if (IndexChecker(coords[0], coords[1], matrix))
                {
                    matrix[coords[0], coords[1]] = 1;
                    sb.Append($"{coords[0]} {coords[1]}");
                    plantedFlowersCoords.Add(sb.ToString());
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }

                sb.Clear();
            }


            foreach (var flowerCoord in plantedFlowersCoords)
            {
                int[] coords = flowerCoord.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                int row = coords[0];
                int col = coords[1];

                row--;
                while (row >= 0)
                {
                    matrix[row, col] += 1;
                    --row;
                }

                row = coords[0];
                col = coords[1];

                row++;
                while (row <= matrix.GetLength(0) - 1)
                {
                    matrix[row, col] += 1;
                    ++row;
                }

                row = coords[0];
                col = coords[1];

                col--;
                while (col >= 0)
                {
                    matrix[row, col] += 1;
                    --col;
                }

                row = coords[0];
                col = coords[1];

                col++;
                while (col <= matrix.GetLength(1) - 1)
                {
                    matrix[row, col] += 1;
                    ++col;
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }

        static bool IndexChecker(int row, int col, int[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && 
                   col >= 0 && col < matrix.GetLength(1);
        }
    }
}
