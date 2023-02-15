namespace P02
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[matrixSize, matrixSize];
            int[] position = new int[2];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string line = Console.ReadLine();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (line[j] == 'V')
                    {
                        position[0] = i;
                        position[1] = j;
                        matrix[i, j] = '*';
                        continue;
                    }

                    matrix[i, j] = line[j];
                }
            }


            int holesMade = 1;
            int rodsHit = 0;
            bool electrocuted = false;

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                int row = position[0];
                int col = position[1];
                int previousRow = position[0];
                int previousCol = position[1];

                switch (command)
                {
                    case "up" when IndexChecker(--row, col, matrix):
                        position[0]--;
                        break;
                    case "down" when IndexChecker(++row, col, matrix):
                        position[0]++;
                        break;
                    case "right" when IndexChecker(row, ++col, matrix):
                        position[1]++;
                        break;
                    case "left" when IndexChecker(row, --col, matrix):
                        position[1]--;
                        break;
                    default:
                        continue;
                }

                row = position[0];
                col = position[1];

                switch (matrix[row, col])
                {
                    case 'C':
                        matrix[row, col] = 'E';
                        holesMade++;
                        electrocuted = true;
                        break;
                    case '*':
                        Console.WriteLine($"The wall is already destroyed at position [{row}, {col}]!");
                        break;
                    case 'R':
                        Console.WriteLine("Vanko hit a rod!");
                        rodsHit++;
                        position[0] = previousRow;
                        position[1] = previousCol;
                        break;
                    default:
                        matrix[row, col] = '*';
                        holesMade++;
                        break;
                }

                if (electrocuted)
                {
                    break;
                }
            }

            Console.WriteLine(electrocuted
                ? $"Vanko got electrocuted, but he managed to make {holesMade} hole(s)."
                : $"Vanko managed to make {holesMade} hole(s) and he hit only {rodsHit} rod(s).");

            matrix[position[0], position[1]] = !electrocuted ? 'V' : 'E';

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }

        }

        private static bool IndexChecker(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1);
        }
    }
}
