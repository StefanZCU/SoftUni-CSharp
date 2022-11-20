using System;
using System.Linq;

namespace _9._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];

            int totalCoal = 0;
            int[] startPosition = new int[2];

            string[] movementCommands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currentCol = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentCol[col];

                    if (currentCol[col] == 'c')
                    {
                        totalCoal++;
                    }
                    else if (currentCol[col] == 's')
                    {
                        startPosition[0] = row;
                        startPosition[1] = col;
                    }
                }
            }

            int collectedCoal = 0;
            bool flag = true;

            for (int i = 0; i < movementCommands.Length; i++)
            {
                startPosition = MovementChecker(movementCommands[i], startPosition, matrix);

                int row = startPosition[0];
                int col = startPosition[1];

                if (matrix[row, col] == 'c')
                {
                    matrix[row, col] = '*';
                    collectedCoal++;

                    if (collectedCoal == totalCoal)
                    {
                        Console.WriteLine($"You collected all coals! ({row}, {col})");
                        flag = false;
                        break;
                    }
                }
                else if (matrix[row, col] == 'e')
                {
                    Console.WriteLine($"Game over! ({row}, {col})");
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                Console.WriteLine($"{totalCoal - collectedCoal} coals left. ({startPosition[0]}, {startPosition[1]})"); 
            }

        }

        static int[] MovementChecker(string command, int[] currentPos, char[,] matrix)
        {
            int row = currentPos[0];
            int col = currentPos[1];

            if (command == "up")
            {
                if (row - 1 >= 0)
                {
                    currentPos[0] = row - 1;
                }
            }
            else if (command == "down")
            {
                if (row + 1 < matrix.GetLength(0))
                {
                    currentPos[0] = row + 1;
                }
            }
            else if (command == "left")
            {
                if (col - 1 >= 0)
                {
                    currentPos[1] = col - 1;
                }
            }
            else if (command == "right")
            {
                if (col + 1 < matrix.GetLength(1))
                {
                    currentPos[1] = col + 1;
                }
            }

            return currentPos;
        }
    }
}
