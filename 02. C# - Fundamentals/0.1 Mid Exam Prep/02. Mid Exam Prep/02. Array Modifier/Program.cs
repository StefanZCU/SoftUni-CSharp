using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _02._Array_Modifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] intArr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] input = command.Split();

                if (input[0] == "swap")
                {
                    intArr = GetSwap(intArr, int.Parse(input[1]), int.Parse(input[2]));
                }
                else if (input[0] == "multiply")
                {
                    intArr = GetMultiply(intArr, int.Parse(input[1]), int.Parse(input[2]));
                }
                else if (input[0] == "decrease")
                {
                    intArr = GetDecrease(intArr);
                }
            }

            Console.WriteLine(String.Join(", ", intArr));

            static int[] GetSwap(int[] intArr, int index1, int index2)
            {
                int tempNum = intArr[index1];
                intArr[index1] = intArr[index2];
                intArr[index2] = tempNum;

                return intArr;
            }

            static int[] GetMultiply(int[] intArr, int index1, int index2)
            {
                intArr[index1] = intArr[index1] * intArr[index2];
                return intArr;
            }

            static int[] GetDecrease(int[] intArr)
            {
                for (int i = 0; i < intArr.Length; i++)
                {
                    intArr[i]--;
                }

                return intArr;
            }
        }
    }
}