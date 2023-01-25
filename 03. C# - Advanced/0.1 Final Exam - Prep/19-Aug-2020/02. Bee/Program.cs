using System;

namespace _02._Bee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizeMatrix, sizeMatrix];

            int[] beePosition = new int[2];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string line = Console.ReadLine();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = line[j];

                    if (line[j] == 'B')
                    {
                        beePosition[0] = i;
                        beePosition[1] = j;
                        matrix[i, j] = '.';
                    }
                }
            }


            bool leftTerritory = false;
            int pollinatedFlowers = 0;

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                int row = beePosition[0];
                int col = beePosition[1];
                matrix[row, col] = '.';

                (row, col) = BeeMover(row, col, matrix, command, beePosition);

                if (row != beePosition[0] || col != beePosition[1])
                {
                    leftTerritory = true;
                    break;
                }
                if (matrix[row, col] == 'f')
                {
                    pollinatedFlowers++;
                    matrix[row, col] = '.';
                }
                else if (matrix[row, col] == 'O')
                {
                    matrix[row, col] = '.';

                    (row, col) = BeeMover(row, col, matrix, command, beePosition);
                    
                    if (matrix[row, col] == 'f')
                    {
                        pollinatedFlowers++;
                        matrix[row, col] = '.';
                    }
                }
                else
                {
                    matrix[row, col] = '.';
                }
            }

            if (leftTerritory)
            {
                Console.WriteLine("The bee got lost!");
            }

            Console.WriteLine(pollinatedFlowers >= 5 
                ? $"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!" 
                : $"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (beePosition[0] == i && beePosition[1] == j && !leftTerritory)
                    {
                        matrix[i, j] = 'B';
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

        static (int, int) BeeMover(int row, int col, char[,] matrix, string command, int[] beePosition)
        {
            switch (command)
            {
                case "up":
                    if (IndexChecker(--row, col, matrix))
                    {
                        beePosition[0]--;
                    }
                    break;
                case "down":
                    if (IndexChecker(++row, col, matrix))
                    {
                        beePosition[0]++;
                    }
                    break;
                case "left":
                    if (IndexChecker(row, --col, matrix))
                    {
                        beePosition[1]--;
                    }
                    break;
                case "right":
                    if (IndexChecker(row, ++col, matrix))
                    {
                        beePosition[1]++;
                    }
                    break;
            }

            return (row, col);

        }
    }
}
