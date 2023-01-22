using System;
using System.Numerics;

namespace _02._Wall_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());
            char[,] matrix = new char[sizeMatrix, sizeMatrix];

            int[] currentPosition = new int[2];
            int[] previousPosition = new int[2];

            int holesCreated = 1;
            int rodsHit = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = line[j];

                    if (matrix[i, j] == 'V')
                    {
                        currentPosition[0] = i;
                        currentPosition[1] = j;
                        matrix[i, j] = '-';
                    }
                }
            }


            bool electrocuted = false;
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                int row = currentPosition[0];
                int col = currentPosition[1];

                previousPosition[0] = currentPosition[0];
                previousPosition[1] = currentPosition[1];

                if (command == "up" && IndexChecker(--row, col, matrix))
                {
                    currentPosition[0]--;
                }
                else if (command == "down" && IndexChecker(++row, col, matrix))
                {
                    currentPosition[0]++;
                }
                else if (command == "right" && IndexChecker(row, ++col, matrix))
                {
                    currentPosition[1]++;
                }
                else if (command == "left" && IndexChecker(row, --col, matrix))
                {
                    currentPosition[1]--;
                }
                else
                {
                    continue;
                }

                matrix[previousPosition[0], previousPosition[1]] = '*';

                row = currentPosition[0];
                col = currentPosition[1];

                if (matrix[row, col] == 'R')
                {
                    currentPosition[0] = previousPosition[0];
                    currentPosition[1] = previousPosition[1];
                    rodsHit++;
                    Console.WriteLine("Vanko hit a rod!");
                }
                else if (matrix[row, col] == 'C')
                {
                    matrix[row, col] = 'E';
                    holesCreated++;
                    electrocuted = true;
                    break;
                }
                else if (matrix[row, col] == '*')
                {
                    Console.WriteLine($"The wall is already destroyed at position [{row}, {col}]!");
                }
                else
                {
                    matrix[row, col] = '*';
                    holesCreated++;
                }
            }

            Console.WriteLine(electrocuted
                ? $"Vanko got electrocuted, but he managed to make {holesCreated} hole(s)."
                : $"Vanko managed to make {holesCreated} hole(s) and he hit only {rodsHit} rod(s).");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((currentPosition[0] == i && currentPosition[1] == j) && matrix[i, j] != 'E')
                    {
                        matrix[i, j] = 'V';
                    }

                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        static bool IndexChecker(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1);
        }
    }
}
