using System;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rowSize = matrixSize[0];
            int colSize = matrixSize[1];

            int currentPosRow = 0;
            int currentPosCol = 0;

            char[,] matrix = new char[rowSize, colSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string line = Console.ReadLine().Trim();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];

                    if (line[col] == 'P')
                    {
                        currentPosRow = row;
                        currentPosCol = col;
                    }
                }
            }

            string commands = Console.ReadLine().Trim();

            for (int i = 0; i < commands.Length; i++)
            {
                char direction = commands[i];

            }
        }
    }
}
