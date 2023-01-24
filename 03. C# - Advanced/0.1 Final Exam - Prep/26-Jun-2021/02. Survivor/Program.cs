using System;
using System.Linq;

namespace _02._Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixRowLength = int.Parse(Console.ReadLine());

            char[][] matrix = new char[matrixRowLength][];

            int collectedTokens = 0;
            int opponentTokens = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse)
                    .ToArray();
                matrix[i] = new char[line.Length];

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = line[j];
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "Gong")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);

                if (IndexChecker(row, col, matrix))
                {
                    if (input[0] == "Find")
                    {
                        if (matrix[row][col] == 'T')
                        {
                            collectedTokens++;
                            matrix[row][col] = '-';
                        }
                    }
                    else if (input[0] == "Opponent")
                    {
                        string direction = input[3];
                        
                        for (int i = 0; i < 4; i++)
                        {
                            if (IndexChecker(row, col, matrix))
                            {
                                if (matrix[row][col] == 'T')
                                {
                                    opponentTokens++;
                                    matrix[row][col] = '-';
                                }
                            }
                            else
                            {
                                break;
                            }

                            switch (direction)
                            {
                                case "up":
                                    --row;
                                    break;
                                case "down":
                                    ++row;
                                    break;
                                case "left":
                                    --col;
                                    break;
                                case "right":
                                    ++col;
                                    break;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write($"{matrix[i][j]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        static bool IndexChecker(int row, int col, char[][] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length;
        }
    }
}
