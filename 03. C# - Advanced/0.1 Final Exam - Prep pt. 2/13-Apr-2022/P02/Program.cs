using System.Linq;

namespace P02
{
    using System;
    using System.Drawing;

    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizeMatrix, sizeMatrix];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] line = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = line[j];
                }
            }

            int blackTrufflesCollected = 0;
            int whiteTrufflesCollected = 0;
            int summerTrufflesCollected = 0;
            int boarTrufflesCollected = 0;

            string command;
            while ((command = Console.ReadLine()) != "Stop the hunt")
            {
                string[] cmdArgs = command.Split();
                string cmdType = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);

                switch (cmdType)
                {
                    case "Collect":
                        if (IndexChecker(row, col, matrix))
                        {
                            switch (matrix[row, col])
                            {
                                case 'S':
                                    summerTrufflesCollected++;
                                    break;
                                case 'B':
                                    blackTrufflesCollected++;
                                    break;
                                case 'W':
                                    whiteTrufflesCollected++;
                                    break;
                            }

                            matrix[row, col] = '-';
                        }
                        break;
                    case "Wild_Boar":
                        string direction = cmdArgs[3];

                        while (IndexChecker(row, col, matrix))
                        {
                            if (BoarTruffleChecker(row, col, matrix))
                            {
                                boarTrufflesCollected++;
                                matrix[row, col] = '-';
                            }

                            switch (direction)
                            {
                                case "up":
                                    row -= 2;
                                    break;
                                case "down":
                                    row += 2;
                                    break;
                                case "right":
                                    col += 2;
                                    break;
                                case "left":
                                    col -= 2;
                                    break;
                            }
                        }

                        break;
                }
            }

            Console.WriteLine($"Peter manages to harvest {blackTrufflesCollected} black, {summerTrufflesCollected} summer, and {whiteTrufflesCollected} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boarTrufflesCollected} truffles.");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }
        private static bool IndexChecker(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
            col >= 0 && col < matrix.GetLength(1);
        }

        private static bool BoarTruffleChecker(int row, int col, char[,] matrix)
        {
            return matrix[row, col] != '-';
        }
    }
}
