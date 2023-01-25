using System;

namespace _02._Snake
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
                        matrix[i, j] = '.';
                    }
                }
            }

            bool fed = false;
            int collectedFood = 0;

            while (true)
            {
                string direction = Console.ReadLine();

                int row = position[0];
                int col = position[1];

                matrix[row, col] = '.';

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
                    case "left":
                        if (IndexChecker(row, --col, matrix))
                        {
                            position[1]--;
                        }
                        break;
                    case "right":
                        if (IndexChecker(row, ++col, matrix))
                        {
                            position[1]++;
                        }
                        break;
                }

                if (row != position[0] || col != position[1])
                {
                    break;
                }

                if (matrix[row, col] == '*')
                {
                    collectedFood++;
                    matrix[row, col] = '.';

                    if (collectedFood == 10)
                    {
                        fed = true;
                        break;
                    }
                }
                else if (matrix[row, col] == 'B')
                {
                    matrix[row, col] = '.';

                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            if (matrix[i, j] == 'B')
                            {
                                matrix[i, j] = '.';
                                position[0] = i;
                                position[1] = j;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(fed 
                ? "You won! You fed the snake." 
                : "Game over!");

            Console.WriteLine($"Food eaten: {collectedFood}");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (position[0] == i && position[1] == j && fed)
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
