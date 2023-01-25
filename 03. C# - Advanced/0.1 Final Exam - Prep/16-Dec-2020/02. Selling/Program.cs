using System;
using System.ComponentModel.Design;
using System.Data;

namespace _02._Selling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizeMatrix, sizeMatrix];

            int[] position = new int[2];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string line = Console.ReadLine();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = line[j];

                    if (line[j] == 'S')
                    {
                        position[0] = i;
                        position[1] = j;
                        matrix[i, j] = '-';
                    }
                }
            }

            int moneyCollected = 0;
            bool collectedEnoughMoney = false;

            while (true)
            {
                string direction = Console.ReadLine();
                int row = position[0];
                int col = position[1];

                matrix[row, col] = '-';

                switch (direction)
                {
                    case "up":
                        if (IndexChecker(--row, col, matrix))
                        {
                            position[0]--;
                        }
                        break;
                    case "down":
                        if (IndexChecker(++row, col, matrix))
                        {
                            position[0]++;
                        }
                        break;
                    case "right":
                        if (IndexChecker(row, ++col, matrix))
                        {
                            position[1]++;
                        }
                        break;
                    case "left":
                        if (IndexChecker(row, --col, matrix))
                        {
                            position[1]--;
                        }
                        break;
                }

                if (row != position[0] || col != position[1])
                {
                    break;
                }

                if (char.IsDigit(matrix[row, col]))
                {
                    moneyCollected += int.Parse(matrix[row, col].ToString());
                    if (moneyCollected < 50) continue;
                    collectedEnoughMoney = true;
                    break;
                }

                if (matrix[row, col] == 'O')
                {
                    matrix[row, col] = '-';

                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            if (matrix[i, j] != 'O') continue;

                            position[0] = i;
                            position[1] = j;
                            matrix[i, j] = '-';
                            break;
                        }
                    }

                    row = position[0];
                    col = position[1];
                }
                else
                {
                    matrix[row, col] = '-';
                }
            }

            Console.WriteLine(collectedEnoughMoney
                ? "Good news! You succeeded in collecting enough money!"
                : "Bad news, you are out of the bakery.");

            Console.WriteLine($"Money: {moneyCollected}");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (position[0] == i && position[1] == j && collectedEnoughMoney)
                    {
                        matrix[i, j] = 'S';
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
