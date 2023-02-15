namespace P02
{
    using System;

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
                    if (line[j] == 'M')
                    {
                        position[0] = i;
                        position[1] = j;
                        matrix[i, j] = '-';
                        continue;
                    }

                    matrix[i, j] = line[j];
                }
            }

            int pointsCollected = 0;
            string command;
            while (pointsCollected < 25 && (command = Console.ReadLine()) != "End")
            {
                int row = position[0];
                int col = position[1];

                switch (command)
                {
                    case "up":
                        if (IndexChecker(--row, col, matrix))
                        {
                            position[0]--;
                        }
                        else
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                        }
                        break;
                    case "down":
                        if (IndexChecker(++row, col, matrix))
                        {
                            position[0]++;
                        }
                        else
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                        }
                        break;
                    case "left":
                        if (IndexChecker(row, --col, matrix))
                        {
                            position[1]--;
                        }
                        else
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                        }
                        break;
                    case "right":
                        if (IndexChecker(row, ++col, matrix))
                        {
                            position[1]++;
                        }
                        else
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                        }
                        break;
                }

                row = position[0];
                col = position[1];

                switch (matrix[row, col])
                {
                    case 'S':
                        matrix[row, col] = '-';
                        pointsCollected -= 3;
                        bool flag = false;
                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                if (matrix[i, j] != 'S') continue;
                                position[0] = i;
                                position[1] = j;
                                flag = true;
                                matrix[i, j] = '-';
                                break;
                            }

                            if (flag)
                            {
                                break;
                            }
                        }
                        break;

                    default:
                        if (char.IsDigit(matrix[row, col]))
                        {
                            pointsCollected += int.Parse(matrix[row, col].ToString());
                        }
                        matrix[row, col] = '-';
                        break;
                }
            }

            Console.WriteLine(pointsCollected >= 25
                ? $"Yay! The Mole survived another game!\nThe Mole managed to survive with a total of {pointsCollected} points."
                : $"Too bad! The Mole lost this battle!\nThe Mole lost the game with a total of {pointsCollected} points.");

            matrix[position[0], position[1]] = 'M';

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
