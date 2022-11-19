using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowAndColsLength = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rowAndColsLength, rowAndColsLength];

            int firstDiagonal = 0;
            int secondDiagonal = 0;

            for (int i = 0; i < rowAndColsLength; i++)
            {
                int[] cols = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < rowAndColsLength; j++)
                {
                    matrix[i, j] = cols[j];

                    if (i == j)
                    {
                        firstDiagonal += cols[j];
                    }
                }
            }

            int k = 0;
            int l = matrix.GetLength(1) - 1;

            while (true)
            {
                secondDiagonal += matrix[k, l];

                if (k == matrix.GetLength(1) - 1 || l < 0)
                {
                    break;
                }

                k++;
                l--;
                
            }

            Console.WriteLine(Math.Abs(firstDiagonal - secondDiagonal));

        }
    }
}
