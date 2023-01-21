using System;
using System.Linq;

namespace _02._Warships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];

            int firstPlayerShips = 0;
            int secondPlayerShips = 0;
            int totalShipsSunk = 0;

            string[] attacks = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < matrixSize; i++)
            {
                char[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = line[j];

                    if (matrix[i, j] == '<')
                    {
                        firstPlayerShips++;
                    }
                    else if (matrix[i, j] == '>')
                    {
                        secondPlayerShips++;
                    }
                }
            }

            for (int i = 0; i < attacks.Length; i++)
            {
                int[] currentCoord = attacks[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();

                int row = currentCoord[0];
                int col = currentCoord[1];

                if (IndexChecker(row, col, matrix))
                {
                    if (matrix[row, col] == '<')
                    {
                        firstPlayerShips--;
                        matrix[row, col] = 'X';
                        totalShipsSunk++;
                    }
                    else if (matrix[row, col] == '>')
                    {
                        secondPlayerShips--;
                        matrix[row, col] = 'X';
                        totalShipsSunk++;
                    }
                    else if (matrix[row, col] == '#')
                    {
                        matrix[row, col] = 'X';
                        (firstPlayerShips, secondPlayerShips, totalShipsSunk) = MineExploder(row, col, matrix, firstPlayerShips, secondPlayerShips, totalShipsSunk);
                    }
                }

                if (secondPlayerShips == 0)
                {
                    Console.WriteLine($"Player One has won the game! {totalShipsSunk} ships have been sunk in the battle.");
                    return;
                }
                
                if (firstPlayerShips == 0)
                {
                    Console.WriteLine($"Player Two has won the game! {totalShipsSunk} ships have been sunk in the battle.");
                    return;
                }
            }

            Console.WriteLine($"It's a draw! Player One has {firstPlayerShips} ships left. Player Two has {secondPlayerShips} ships left.");

        }

        static bool IndexChecker(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1);
        }

        static (int, int, int) MineExploder(int row, int col, char[,] matrix, int firstPlayer, int secondPlayer, int totalShips)
        {
            int[,] coords =
            {
                { row + 1, col + 1 },
                { row + 1, col },
                { row + 1, col - 1 },
                { row, col + 1 },
                { row, col - 1 },
                { row - 1, col + 1 },
                { row - 1, col },
                { row - 1, col - 1 }

            };

            for (int i = 0; i < coords.GetLength(0); i++)
            {
                if (IndexChecker(coords[i, 0], coords[i, 1], matrix))
                {
                    if (matrix[coords[i, 0], coords[i, 1]] == '<')
                    {
                        firstPlayer--;
                        totalShips++;
                    }
                    else if (matrix[coords[i, 0], coords[i, 1]] == '>')
                    {
                        secondPlayer--;
                        totalShips++;
                    }

                    matrix[coords[i, 0], coords[i, 1]] = 'X';
                }
            }

            return (firstPlayer, secondPlayer, totalShips);
        }
    }
}
