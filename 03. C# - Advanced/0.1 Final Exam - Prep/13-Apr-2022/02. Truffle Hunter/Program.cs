using System;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;

namespace _02._Truffle_Hunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizeMatrix, sizeMatrix];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse)
                    .ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            int blackTrufflesCollected = 0;
            int summerTrufflesCollected = 0;
            int whiteTrufflesCollected = 0;
            int eatenTrufflesBoar = 0;

            string command;
            while ((command = Console.ReadLine()) != "Stop the hunt")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);

                if (input[0] == "Collect")
                {
                    switch (matrix[row, col])
                    {
                        case 'B':
                            blackTrufflesCollected++;
                            break;
                        case 'S':
                            summerTrufflesCollected++;
                            break;
                        case 'W':
                            whiteTrufflesCollected++;
                            break;
                    }

                    matrix[row, col] = '-';
                }
                else if (input[0] == "Wild_Boar")
                {
                    string direction = input[3];

                    while (IndexChecker(row, col, matrix))
                    {
                        if (TruffleChecker(row, col, matrix))
                        {
                            eatenTrufflesBoar++;
                            matrix[row, col] = '-';
                        }

                        switch (direction)
                        {
                            case "up":
                                row -= 2;
                                break;
                            case "down":
                                row += 2;
                                break;
                            case "right":
                                col += 2;
                                break;
                            case "left":
                                col -= 2;
                                break;
                        }
                    }
                }
            }

            Console.WriteLine($"Peter manages to harvest {blackTrufflesCollected} black, {summerTrufflesCollected} summer, and {whiteTrufflesCollected} white truffles.");
            Console.WriteLine($"The wild boar has eaten {eatenTrufflesBoar} truffles.");

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

        static bool TruffleChecker(int row, int col, char[,] matrix)
        {
            if (matrix[row, col] != '-')
            {
                return true;
            }

            return false;
        }
    }
}
