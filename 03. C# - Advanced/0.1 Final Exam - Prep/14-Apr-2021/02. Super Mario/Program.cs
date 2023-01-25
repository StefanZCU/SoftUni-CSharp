using System;

namespace _02._Super_Mario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int marioLives = int.Parse(Console.ReadLine());
            int sizeMatrix = int.Parse(Console.ReadLine());

            char[][] matrix = new char[sizeMatrix][];

            int[] position = new int[2];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string line = Console.ReadLine();

                matrix[i] = new char[line.Length];

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (line[j] == 'M')
                    {
                        position[0] = i;
                        position[1] = j;
                        matrix[i][j] = '-';
                        continue;
                    }

                    matrix[i][j] = line[j];
                }
            }

            string command = Console.ReadLine();
            bool dead = false;
            bool win = false;
            while (true)
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string direction = input[0];
                int bowserRow = int.Parse(input[1]);
                int bowserCol = int.Parse(input[2]);

                matrix[bowserRow][bowserCol] = 'B';

                int marioRow = position[0];
                int marioCol = position[1];

                matrix[marioRow][marioCol] = '-';

                switch (direction)
                {
                    case "W":
                        if (IndexChecker(--marioRow, marioCol, matrix)) position[0]--;
                        break;
                    case "S":
                        if (IndexChecker(++marioRow, marioCol, matrix)) position[0]++;
                        break;
                    case "D":
                        if (IndexChecker(marioRow, ++marioCol, matrix)) position[1]++;
                        break;
                    case "A":
                        if (IndexChecker(marioRow, --marioCol, matrix)) position[1]--;
                        break;
                }
                marioLives--;
                marioRow = position[0];
                marioCol = position[1];

                if (matrix[marioRow][marioCol] == 'P')
                {
                    matrix[marioRow][marioCol] = '-';
                    win = true;
                    break;
                }

                if (matrix[marioRow][marioCol] == 'B')
                {
                    marioLives -= 2;

                    matrix[marioRow][marioCol] = '-';
                }

                if (marioLives <= 0)
                {
                    matrix[marioRow][marioCol] = 'X';
                    dead = true;
                    break;
                }

                command = Console.ReadLine();
            }

            if (dead)
            {
                Console.WriteLine($"Mario died at {position[0]};{position[1]}.");
            }

            if (win)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioLives}");
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j]);
                }

                Console.WriteLine();
            }


        }

        static bool IndexChecker(int row, int col, char[][] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix[row].Length;
        }
    }
}
