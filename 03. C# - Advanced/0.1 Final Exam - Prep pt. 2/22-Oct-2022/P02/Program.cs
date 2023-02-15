namespace P02
{
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());
            string racingNumber = Console.ReadLine();

            char[,] matrix = new char[sizeMatrix, sizeMatrix];
            int[] position = { 0, 0 };

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            int kmPassed = 0;
            bool won = false;
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                switch (command)
                {
                    case "up":
                        position[0]--;
                        break;
                    case "down":
                        position[0]++;
                        break;
                    case "left":
                        position[1]--;
                        break;
                    case "right":
                        position[1]++;
                        break;
                }

                int row = position[0];
                int col = position[1];

                kmPassed += 10;

                switch (matrix[row, col])
                {
                    case 'T':
                        {
                            bool flag = false;
                            matrix[row, col] = '.';
                            for (int i = 0; i < matrix.GetLength(0); i++)
                            {
                                for (int j = 0; j < matrix.GetLength(1); j++)
                                {
                                    if (matrix[i, j] != 'T') continue;

                                    matrix[i, j] = '.';
                                    flag = true;
                                    position[0] = i;
                                    position[1] = j;
                                    break;
                                }

                                if (flag)
                                {
                                    break;
                                }
                            }

                            kmPassed += 20;
                            break;
                        }
                    case 'F':
                        won = true;
                        break;
                }

                if (won)
                {
                    break;
                }
            }

            Console.WriteLine(!won
                ? $"Racing car {racingNumber} DNF."
                : $"Racing car {racingNumber} finished the stage!");

            Console.WriteLine($"Distance covered {kmPassed} km.");

            matrix[position[0], position[1]] = 'C';

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}