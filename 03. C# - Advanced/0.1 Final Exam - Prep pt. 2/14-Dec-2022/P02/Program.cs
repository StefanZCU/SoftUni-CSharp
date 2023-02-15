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
                    if (line[j] == 'S')
                    {
                        position[0] = i;
                        position[1] = j;
                        matrix[i, j] = '-';
                        continue;
                    }

                    matrix[i, j] = line[j];
                }
            }

            int destroyedShips = 0;
            int minesHit = 0;

            while (true)
            {
                string command = Console.ReadLine();

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

                switch (matrix[row, col])
                {
                    case '-':
                        continue;
                    case '*':
                        matrix[row, col] = '-';
                        minesHit++;
                        break;
                    case 'C':
                        matrix[row, col] = '-';
                        destroyedShips++;
                        break;
                }

                if (minesHit == 3)
                {
                    Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{row}, {col}]!");
                    break;
                }

                if (destroyedShips != 3) continue;
                Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                break;
            }

            matrix[position[0], position[1]] = 'S';

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
