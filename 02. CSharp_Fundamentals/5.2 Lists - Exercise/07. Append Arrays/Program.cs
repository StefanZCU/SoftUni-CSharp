using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<int> finalNumberList = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                string currentNum = numbers[i];

                int[] currentArr = currentNum.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < currentArr.Length; j++)
                {
                    finalNumberList.Insert(j, currentArr[j]);
                }
            }

            foreach (int item in finalNumberList)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
