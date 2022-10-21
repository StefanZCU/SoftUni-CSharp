using System;
using System.Linq;

namespace _03._Zig_Zag_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int[] row1 = new int[num];
            int[] row2 = new int[num];


            for (int i = 0; i < num; i++)
            {
                int[] rowNums = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (i % 2 == 0)
                {
                    row1[i] = rowNums[0];
                    row2[i] = rowNums[1];
                }
                else
                {
                    row1[i] = rowNums[1];
                    row2[i] = rowNums[0];
                }
            }

            Console.WriteLine(String.Join(" ", row1));
            Console.WriteLine(String.Join(" ", row2));
        }
    }
}
