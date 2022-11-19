using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] cols = Console.ReadLine().Split().Select(int.Parse).ToArray();

                jaggedArray[i] = new int[cols.Length];

                for (int j = 0; j < cols.Length; j++)
                {
                    jaggedArray[i][j] = cols[j];
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] input = command.Split();

                if (input[0] == "Add")
                {
                    int row = int.Parse(input[1]);
                    int col = int.Parse(input[2]);
                    int value = int.Parse(input[3]);

                    if (row < jaggedArray.Length && row >= 0 && col >= 0 && col < jaggedArray[row].Length)
                    {
                        jaggedArray[row][col] += value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                else if (input[0] == "Subtract")
                {
                    int row = int.Parse(input[1]);
                    int col = int.Parse(input[2]);
                    int value = int.Parse(input[3]);

                    if (row < jaggedArray.Length && row >= 0 && col >= 0 && col < jaggedArray[row].Length)
                    {
                        jaggedArray[row][col] -= value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write($"{jaggedArray[i][j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
