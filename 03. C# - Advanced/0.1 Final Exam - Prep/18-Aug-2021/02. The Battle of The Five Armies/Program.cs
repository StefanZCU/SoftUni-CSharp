using System;

namespace _02._The_Battle_of_The_Five_Armies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armorAmt = int.Parse(Console.ReadLine());
            int sizeMatrix = int.Parse(Console.ReadLine());

            char[][] matrix = new char[sizeMatrix][];

            int[] armyPos = new int[2];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string line = Console.ReadLine();

                matrix[i] = new char[line.Length];

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (line[j] == 'A')
                    {
                        armyPos[0] = i;
                        armyPos[1] = j;
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
                int orcRow = int.Parse(input[1]);
                int orcCol = int.Parse(input[2]);

                matrix[orcRow][orcCol] = 'O';

                int armyRow = armyPos[0];
                int armyCol = armyPos[1];

                matrix[armyRow][armyCol] = '-';

                switch (direction)
                {
                    case "up":
                        if (IndexChecker(--armyRow, armyCol, matrix)) armyPos[0]--;
                        break;
                    case "down":
                        if (IndexChecker(++armyRow, armyCol, matrix)) armyPos[0]++;
                        break;
                    case "right":
                        if (IndexChecker(armyRow, ++armyCol, matrix)) armyPos[1]++;
                        break;
                    case "left":
                        if (IndexChecker(armyRow, --armyCol, matrix)) armyPos[1]--;
                        break;
                }
                armorAmt--;
                armyRow = armyPos[0];
                armyCol = armyPos[1];

                if (matrix[armyRow][armyCol] == 'M')
                {
                    matrix[armyRow][armyCol] = '-';
                    win = true;
                    break;
                }

                if (matrix[armyRow][armyCol] == 'O')
                {
                    armorAmt -= 2;

                    matrix[armyRow][armyCol] = '-';
                }

                if (armorAmt <= 0)
                {
                    matrix[armyRow][armyCol] = 'X';
                    dead = true;
                    break;
                }

                command = Console.ReadLine();
            }

            if (dead)
            {
                Console.WriteLine($"The army was defeated at {armyPos[0]};{armyPos[1]}.");
            }

            if (win)
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armorAmt}");
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
