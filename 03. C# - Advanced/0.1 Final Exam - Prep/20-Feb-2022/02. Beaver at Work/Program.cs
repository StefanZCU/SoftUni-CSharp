using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Beaver_at_Work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizeMatrix, sizeMatrix];

            int[] position = new int[2];
            int totalBranches = 0;
            List<char> collectedBranches = new List<char>();


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

                    if (char.IsLetter(line[j]) && char.IsLower(line[j]))
                    {
                        totalBranches++;
                    }

                    matrix[i, j] = line[j];
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                int row = position[0];
                int col = position[1];

                if (BeaverMover(row, col, matrix, command, position))
                {
                    row = position[0];
                    col = position[1];

                    if (char.IsLetter(matrix[row, col]) && char.IsLower(matrix[row, col]))
                    {
                        collectedBranches.Add(matrix[row, col]);
                        matrix[row, col] = '-';
                    }
                    else if (matrix[row, col] == 'F')
                    {
                        matrix[row, col] = '-';

                        switch (command)
                        {
                            case "up":

                                if (!IndexChecker(--row, col, matrix))
                                {
                                    position[0] = matrix.GetLength(0) - 1;
                                }
                                else
                                {
                                    position[0] = 0;
                                }

                                break;
                            case "down":

                                if (!IndexChecker(++row, col, matrix))
                                {
                                    position[0] = 0;
                                }
                                else
                                {
                                    position[0] = matrix.GetLength(0) - 1;
                                }

                                break;
                            case "left":

                                if (!IndexChecker(row, --col, matrix))
                                {
                                    position[1] = matrix.GetLength(1) - 1;
                                }
                                else
                                {
                                    position[1] = 0;
                                }

                                break;
                            case "right":

                                if (!IndexChecker(row, ++col, matrix))
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

                        if (char.IsLetter(matrix[row, col]) && char.IsLower(matrix[row, col]))
                        {
                            collectedBranches.Add(matrix[row, col]);
                            matrix[row, col] = '-';
                        }
                    }
                }
                else
                {
                    if (collectedBranches.Count > 0)
                    {
                        collectedBranches.RemoveAt(collectedBranches.Count - 1);
                        totalBranches--;
                    }
                }

                if (collectedBranches.Count == totalBranches)
                {
                    break;
                }

            }

            Console.WriteLine(collectedBranches.Count == totalBranches
                ? $"The Beaver successfully collect {collectedBranches.Count} wood branches: {string.Join(", ", collectedBranches)}."
                : $"The Beaver failed to collect every wood branch. There are {totalBranches - collectedBranches.Count} branches left.");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (position[0] == i && position[1] == j)
                    {
                        matrix[i, j] = 'B';
                    }

                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }

        static bool IndexChecker(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }

        static bool BeaverMover(int row, int col, char[,] matrix, string direction, int[] position)
        {

            if (direction == "up" && IndexChecker(--row, col, matrix))
            {
                position[0]--;
                return true;
            }
            else if (direction == "down" && IndexChecker(++row, col, matrix))
            {
                position[0]++;
                return true;
            }
            else if (direction == "left" && IndexChecker(row, --col, matrix))
            {
                position[1]--;
                return true;
            }
            else if (direction == "right" && IndexChecker(row, ++col, matrix))
            {
                position[1]++;
                return true;
            }

            return false;
        }
    }
}
