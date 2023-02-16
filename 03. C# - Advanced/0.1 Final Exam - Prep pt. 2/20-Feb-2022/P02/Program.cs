using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace P02
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizeMatrix, sizeMatrix];
            int[] position = new int[2];
            int totalBranches = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] line = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (line[j] == 'B')
                    {
                        matrix[i, j] = '-';
                        position[0] = i;
                        position[1] = j;
                        continue;
                    }
                    
                    if (char.IsLower(line[j]))
                    {
                        totalBranches++;
                    }

                    matrix[i, j] = line[j];
                }
            }

            List<char> branchesCollected = new List<char>();
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (!BeaverMover(position, matrix, command) && branchesCollected.Count != 0)
                {
                    branchesCollected.RemoveAt(branchesCollected.Count - 1);
                    totalBranches--;
                }
                else
                {
                    int row = position[0];
                    int col = position[1];

                    switch (matrix[row, col])
                    {
                        case 'F':
                            matrix[row, col] = '-';
                            switch (command)
                            {
                                case "up":
                                    if (row == 0)
                                    {
                                        position[0] = matrix.GetLength(0) - 1;
                                    }
                                    else
                                    {
                                        position[0] = 0;
                                    }
                                    break;
                                case "down":
                                    if (row == matrix.GetLength(0) - 1)
                                    {
                                        position[0] = 0;
                                    }
                                    else
                                    {
                                        position[0] = matrix.GetLength(0) - 1;
                                    }
                                    break;
                                case "left":
                                    if (col == 0)
                                    {
                                        position[1] = matrix.GetLength(1) - 1;
                                    }
                                    else
                                    {
                                        position[1] = 0;
                                    }
                                    break;
                                case "right":
                                    if (col == matrix.GetLength(1) - 1)
                                    {
                                        position[1] = 0;
                                    }
                                    else
                                    {
                                        position[1] = matrix.GetLength(1) - 1;
                                    }
                                    break;

                            }

                            row = position[0];
                            col = position[1];

                            if (CellChecker(row, col, matrix))
                            {
                                branchesCollected.Add(matrix[row, col]);
                            }
                            break;
                        default:
                            if (CellChecker(row, col, matrix))
                            {
                                branchesCollected.Add(matrix[row, col]);
                            }
                            break;
                    }

                    matrix[row, col] = '-';

                    if (branchesCollected.Count == totalBranches)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(branchesCollected.Count == totalBranches 
                ? $"The Beaver successfully collect {totalBranches} wood branches: {string.Join(", ", branchesCollected)}." 
                : $"The Beaver failed to collect every wood branch. There are {totalBranches - branchesCollected.Count} branches left.");


            matrix[position[0], position[1]] = 'B';

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }

        static bool IndexChecker(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1);
        }

        static bool BeaverMover(int[] position, char[,] matrix, string direction)
        {
            int row = position[0];
            int col = position[1];

            switch (direction)
            {
                case "up":
                    if (IndexChecker(--row, col, matrix))
                    {
                        position[0]--;
                        return true;
                    }
                    break;
                case "down":
                    if (IndexChecker(++row, col, matrix))
                    {
                        position[0]++;
                        return true;
                    }
                    break;
                case "left":
                    if (IndexChecker(row, --col, matrix))
                    {
                        position[1]--;
                        return true;
                    }
                    break;
                case "right":
                    if (IndexChecker(row, ++col, matrix))
                    {
                        position[1]++;
                        return true;
                    }
                    break;
            }

            return false;
        }

        static bool CellChecker(int row, int col, char[,] matrix)
        {
            return char.IsLower(matrix[row, col]);
        }
    }
}
