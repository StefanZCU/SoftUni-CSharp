using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace _7._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string line = Console.ReadLine().Trim();

                for (int col = 0; col < line.Length; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            int removedKnights = 0;
            int knightToRemoveRow = 0;
            int knightToRemoveCol = 0;

            while (true)
            {
                int mostAttacks = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            int currentAttacks = 0;

                            currentAttacks = GetAttacks(matrix, row, col);

                            if (currentAttacks > mostAttacks)
                            {
                                mostAttacks = currentAttacks;
                                knightToRemoveRow = row;
                                knightToRemoveCol = col;
                            }
                        }
                    }
                }
                
                if (mostAttacks == 0)
                {
                    break;
                }

                if (mostAttacks != 0)
                {
                    matrix[knightToRemoveRow, knightToRemoveCol] = '0';
                    removedKnights++;
                }
            }

            Console.WriteLine(removedKnights);
        }

        static int GetAttacks(char[,] matrix, int row, int col)
        {
            int attacks = 0;

            if (CheckIndex(matrix, row - 2, col - 1))
            {
                attacks++;
            }
            if (CheckIndex(matrix, row - 2, col + 1))
            {
                attacks++;
            }
            if (CheckIndex(matrix, row + 2, col - 1))
            {
                attacks++;
            }
            if (CheckIndex(matrix, row + 2, col + 1))
            {
                attacks++;
            }
            if (CheckIndex(matrix, row - 1, col - 2))
            {
                attacks++;
            }
            if (CheckIndex(matrix, row + 1, col - 2))
            {
                attacks++;
            }
            if (CheckIndex(matrix, row - 1, col + 2))
            {
                attacks++;
            }
            if (CheckIndex(matrix, row + 1, col + 2))
            {
                attacks++;
            }

            return attacks;
        }

        static bool CheckIndex(char[,] matrix, int row, int col)
        {
            if (row >= 0 && col >= 0 && row < matrix.GetLength(0) && col < matrix.GetLength(1) && matrix[row, col] == 'K')
            {
                return true;
            }

            return false;
        }
    }
}
