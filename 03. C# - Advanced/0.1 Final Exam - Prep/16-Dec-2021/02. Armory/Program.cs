using System;
using System.Security.Cryptography;

namespace _02._Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());
            char[,] matrix = new char[sizeMatrix, sizeMatrix];

            int[] officerPosition = new int[2];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string line = Console.ReadLine();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (line[j] == 'A')
                    {
                        officerPosition[0] = i;
                        officerPosition[1] = j;
                        matrix[i, j] = '-';
                        continue;
                    }

                    matrix[i, j] = line[j];
                }
            }

            int boughtSwordsValue = 0;
            bool escaped = false;
            string command;
            while (boughtSwordsValue <= 65)
            {
                command = Console.ReadLine();

                int row = officerPosition[0];
                int col = officerPosition[1];

                switch (command)
                {
                    case "up":
                        if (IndexChecker(--row, col, matrix))
                        {
                            officerPosition[0]--;
                        }
                        else
                        {
                            escaped = true;
                        }
                        break;
                    case "down":
                        if (IndexChecker(++row, col, matrix))
                        {
                            officerPosition[0]++;
                        }
                        else
                        {
                            escaped = true;
                        }
                        break;
                    case "right":
                        if (IndexChecker(row, ++col, matrix))
                        {
                            officerPosition[1]++;
                        }
                        else
                        {
                            escaped = true;
                        }
                        break;
                    case "left":
                        if (IndexChecker(row, --col, matrix))
                        {
                            officerPosition[1]--;
                        }
                        else
                        {
                            escaped = true;
                        }
                        break;
                }

                row = officerPosition[0];
                col = officerPosition[1];

                if (escaped)
                {
                    break;
                }

                if (char.IsDigit(matrix[row, col]))
                {
                    boughtSwordsValue += int.Parse(matrix[row, col].ToString());
                    matrix[row, col] = '-';
                }

                if (matrix[row, col] == 'M')
                {
                    bool flag = false;
                    matrix[row, col] = '-';

                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            if (matrix[i, j] == 'M')
                            {
                                officerPosition[0] = i;
                                officerPosition[1] = j;
                                matrix[i, j] = '-';
                                flag = true;
                                break;
                            }
                        }

                        if (flag)
                        {
                            break;
                        }
                    }
                }
            }


            Console.WriteLine(escaped 
                ? "I do not need more swords!" 
                : "Very nice swords, I will come back for more!");

            Console.WriteLine($"The king paid {boughtSwordsValue} gold coins.");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (!escaped && officerPosition[0] == i && officerPosition[1] == j)
                    {
                        matrix[i, j] = 'A';
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
