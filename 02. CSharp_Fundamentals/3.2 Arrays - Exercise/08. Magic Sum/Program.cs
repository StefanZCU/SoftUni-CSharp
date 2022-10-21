using System;
using System.Linq;

namespace _08._Magic_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] numRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //int magicNum = int.Parse(Console.ReadLine());

            //int[] foundCombos = new int[numRow.Length];
            //bool flag = false;

            //for (int i = 0; i < numRow.Length; i++)
            //{
            //    for (int j = i; j < numRow.Length; j++)
            //    {
            //        for (int k = 0; k < foundCombos.Length; k++)
            //        {
            //            if (numRow[i] == foundCombos[k])
            //            {
            //                flag = true;
            //                break;
            //            }
            //        }

            //        if (numRow[i] + numRow[j] == magicNum && i != j && flag == false)
            //        {
            //            foundCombos[i] += numRow[i];
            //            foundCombos[j] += numRow[j];

            //            Console.WriteLine($"{numRow[i]} {numRow[j]}");
            //        }

            //        if (flag)
            //        {
            //            flag = false;
            //            break;
            //        }

            //    }
            //}


            int[] numRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int magicNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < numRow.Length; i++)
            {
                for (int j = i + 1; j < numRow.Length; j++)
                {
                    if (numRow[i] + numRow[j] == magicNum)
                    {
                        Console.WriteLine($"{numRow[i]} {numRow[j]}");
                    }
                }
            }
        }
    }
}
