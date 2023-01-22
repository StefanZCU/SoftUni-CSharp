using System;
using System.Data;

namespace _02._Help_A_Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];

            int[] position = new int[2];
            int pointsCollected = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string line = Console.ReadLine();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = line[j];

                    if (matrix[i, j] == 'M')
                    {
                        position[0] = i;
                        position[1] = j;
                        matrix[i, j] = '-';
                    }
                }
            }


            bool win = false;
            bool lose = true;
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                int row = position[0];
                int col = position[1];

                if (command == "up" && IndexChecker(--row, col, matrix))
                {
                    position[0]--;
                }
                else if (command == "down" && IndexChecker(++row, col, matrix))
                {
                    position[0]++;
                }
                else if (command == "right" && IndexChecker(row, ++col, matrix))
                {
                    position[1]++;
                }
                else if (command == "left" && IndexChecker(row, --col, matrix))
                {
                    position[1]--;
                }
                else
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                    continue;
                }

                row = position[0];
                col = position[1];

                if (char.IsDigit(matrix[row, col]))
                {
                    pointsCollected += int.Parse(matrix[row, col].ToString());
                    matrix[row, col] = '-';

                    if (pointsCollected >= 25)
                    {
                        win = true;
                        lose = false;
                        break;
                    }
                }

                if (matrix[row, col] == 'S')
                {
                    matrix[row, col] = '-';
                    pointsCollected -= 3;

                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            if (matrix[i, j] == 'S')
                            {
                                matrix[i, j] = '-';
                                position[0] = i;
                                position[1] = j;
                            }
                        }
                    }
                }

            }

            if (win)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {pointsCollected} points.");
            }

            if (lose)
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {pointsCollected} points.");
            }


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (position[0] == i && position[1] == j)
                    {
                        matrix[i, j] = 'M';
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
