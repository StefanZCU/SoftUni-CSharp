using System;
using System.Linq;

namespace _8._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            int[,] matrix = new int[sizeMatrix, sizeMatrix];

            for (int row = 0; row < sizeMatrix; row++)
            {
                int[] cols = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < cols.Length; col++)
                {
                    matrix[row, col] = cols[col];
                }
            }

            string[] bombPositions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < bombPositions.Length; i++)
            {
                matrix = ExplosionChecker(matrix, bombPositions[i]);
            }

            int aliveCells = 0;
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        static int[,] ExplosionChecker(int[,] matrix, string bombCoordinate)
        {
            int[] coords = bombCoordinate.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            if (matrix[coords[0], coords[1]] > 0)
            {
                if (IndexChecker(coords[0] - 1, coords[1] - 1, matrix))
                {
                    matrix[coords[0] - 1, coords[1] - 1] -= matrix[coords[0], coords[1]];
                }
                if (IndexChecker(coords[0] - 1, coords[1], matrix))
                {
                    matrix[coords[0] - 1, coords[1]] -= matrix[coords[0], coords[1]];
                }
                if (IndexChecker(coords[0] - 1, coords[1] + 1, matrix))
                {
                    matrix[coords[0] - 1, coords[1] + 1] -= matrix[coords[0], coords[1]];
                }
                if (IndexChecker(coords[0], coords[1] - 1, matrix))
                {
                    matrix[coords[0], coords[1] - 1] -= matrix[coords[0], coords[1]];
                }
                if (IndexChecker(coords[0], coords[1] + 1, matrix))
                {
                    matrix[coords[0], coords[1] + 1] -= matrix[coords[0], coords[1]];
                }
                if (IndexChecker(coords[0] + 1, coords[1] - 1, matrix))
                {
                    matrix[coords[0] + 1, coords[1] - 1] -= matrix[coords[0], coords[1]];
                }
                if (IndexChecker(coords[0] + 1, coords[1], matrix))
                {
                    matrix[coords[0] + 1, coords[1]] -= matrix[coords[0], coords[1]];
                }
                if (IndexChecker(coords[0] + 1, coords[1] + 1, matrix))
                {
                    matrix[coords[0] + 1, coords[1] + 1] -= matrix[coords[0], coords[1]];
                }

                matrix[coords[0], coords[1]] = 0;
            }
            
            return matrix;
        }

        static bool IndexChecker(int row, int col, int[,] matrix)
        {
            if (row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1) && matrix[row, col] > 0)
            {
                return true;
            }
            return false;
        }
    }
}
