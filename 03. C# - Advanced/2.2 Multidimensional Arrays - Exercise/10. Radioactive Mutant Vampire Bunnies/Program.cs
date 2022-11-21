using System;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rowSize = matrixSize[0];
            int colSize = matrixSize[1];

            int currentPosRow = 0;
            int currentPosCol = 0;

            char[,] matrix = new char[rowSize, colSize];
            char[,] oldBunnyMatrix = new char[rowSize, colSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string line = Console.ReadLine().Trim();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                    oldBunnyMatrix[row, col] = line[col];

                    if (line[col] == 'P')
                    {
                        currentPosRow = row;
                        currentPosCol = col;
                        matrix[row, col] = '.';
                        oldBunnyMatrix[row, col] = '.';
                    }
                }
            }

            string commands = Console.ReadLine().Trim();
            bool flagWin = false;
            bool flagLose = false;

            int winningRow = 0;
            int winningCol = 0;

            for (int i = 0; i < commands.Length; i++)
            {
                char direction = commands[i];

                if (direction == 'U')
                {
                    if (IndexChecker(matrix, currentPosRow - 1, currentPosCol))
                    {
                        winningCol = currentPosCol;
                        winningRow = currentPosRow;
                        flagWin = true;
                    }
                    else
                    {
                        currentPosRow--;
                    }
                }
                else if (direction == 'D')
                {
                    if (IndexChecker(matrix, currentPosRow + 1, currentPosCol))
                    {
                        winningCol = currentPosCol;
                        winningRow = currentPosRow;
                        flagWin = true;
                    }
                    else
                    {
                        currentPosRow++;
                    }
                }
                else if (direction == 'L')
                {
                    if (IndexChecker(matrix, currentPosRow, currentPosCol - 1))
                    {
                        winningCol = currentPosCol;
                        winningRow = currentPosRow;
                        flagWin = true;
                    }
                    else
                    {
                        currentPosCol--;
                    }
                }
                else if (direction == 'R')
                {
                    if (IndexChecker(matrix, currentPosRow, currentPosCol + 1))
                    {
                        winningCol = currentPosCol;
                        winningRow = currentPosRow;
                        flagWin = true;
                    }
                    else
                    {
                        currentPosCol++;
                    }
                }

                if (matrix[currentPosRow, currentPosCol] == 'B' && !flagWin)
                {
                    flagLose = true;
                }

                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    for (int k = 0; k < matrix.GetLength(1); k++)
                    {
                        if (oldBunnyMatrix[j, k] == 'B')
                        {
                            if (!IndexChecker(matrix, j - 1, k))
                            {
                                matrix[j - 1, k] = 'B';
                            }
                            if (!IndexChecker(matrix, j + 1, k))
                            {
                                matrix[j + 1, k] = 'B';
                            }
                            if (!IndexChecker(matrix, j, k - 1))
                            {
                                matrix[j, k - 1] = 'B';
                            }
                            if (!IndexChecker(matrix, j, k + 1))
                            {
                                matrix[j, k + 1] = 'B';
                            }
                        }
                    }
                }

                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    for (int k = 0; k < matrix.GetLength(1); k++)
                    {
                        oldBunnyMatrix[j, k] = matrix[j, k];
                    }
                }

                if ((matrix[currentPosRow, currentPosCol] == 'B' && !flagWin) || flagLose)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"dead: {currentPosRow} {currentPosCol}");
                    break;
                }

                if (flagWin)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"won: {winningRow} {winningCol}");
                    break;
                }
            }
        }

        static bool IndexChecker(char[,] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return false;
            }

            return true;
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    Console.Write($"{matrix[j, k]}");
                }

                Console.WriteLine();
            }
        }
    }
}
