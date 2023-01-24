using System;

namespace _02._Re_Volt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());
            int numCommands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizeMatrix, sizeMatrix];
            int[] position = new int[2];
            int[] prevPosition = new int[2];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string line = Console.ReadLine();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = line[j];

                    if (line[j] == 'f')
                    {
                        position[0] = i;
                        position[1] = j;
                        matrix[i, j] = '-';
                    }
                }
            }

            for (int i = 0; i < numCommands; i++)
            {
                int row = position[0];
                int col = position[1];

                prevPosition[0] = position[0];
                prevPosition[1] = position[1];

                string command = Console.ReadLine();

                (row, col) = PlayerMover(row, col, matrix, position, command);
                
                if (matrix[row, col] == 'B')
                {
                    (row, col) = PlayerMover(row, col, matrix, position, command);
                }

                if (matrix[row, col] == 'T')
                {
                    position[0] = prevPosition[0];
                    position[1] = prevPosition[1];

                    row = position[0];
                    col = position[1];
                }

                if (matrix[row, col] == 'F')
                {
                    Console.WriteLine("Player won!");
                    MatrixPrinter(matrix, position);
                    return;
                }
            }

            Console.WriteLine("Player lost!");
            MatrixPrinter(matrix, position);
        }

        static bool IndexChecker(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && 
                   col >= 0 && col < matrix.GetLength(1);

        }

        static (int, int) PlayerMover(int row, int col, char[,] matrix, int[] position, string command)
        {
            switch (command)
            {
                case "up":
                    if (IndexChecker(--row, col, matrix))
                    {
                        position[0]--;
                    }
                    else
                    {
                        position[0] = matrix.GetLength(0) - 1;
                    }
                    break;
                case "down":
                    if (IndexChecker(++row, col, matrix))
                    {
                        position[0]++;
                    }
                    else
                    {
                        position[0] = 0;
                    }
                    break;
                case "left":
                    if (IndexChecker(row, --col, matrix))
                    {
                        position[1]--;
                    }
                    else
                    {
                        position[1] = matrix.GetLength(1) - 1;
                    }
                    break;
                case "right":
                    if (IndexChecker(row, ++col, matrix))
                    {
                        position[1]++;
                    }
                    else
                    {
                        position[1] = 0;
                    }
                    break;
            }

            row = position[0];
            col = position[1];

            return (row, col);
        }

        static void MatrixPrinter(char[,] matrix, int[] position)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (position[0] == i && position[1] == j)
                    {
                        matrix[i, j] = 'f';
                    }

                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
