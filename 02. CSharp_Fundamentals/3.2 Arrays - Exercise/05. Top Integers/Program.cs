//using System;
//using System.Linq;

//namespace _05._Top_Integers
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

//            int[] newNums = new int[nums.Length];

//            for (int i = 0; i < nums.Length; i++)
//            {
//                for (int j = i + 1; j < nums.Length; j++)
//                {
//                    if (nums[i] <= nums[j])
//                    {
//                        break;
//                    }
//                    else if (nums[i] > nums[j])
//                    {
//                        Console.Write($"{nums[i]} ");
//                        break;
//                    }
//                }
//            }
//        }
//    }
//}

using System;
using System.Linq;

namespace _01._Hello_Softuni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] topIntegers = new int[arr.Length];

            int topIntegersIndex = 0;

            for (int i = 0; i <= arr.Length - 1; i++)
            {
                int currentNum = arr[i];
                bool isTopInteger = true;

                //Loops through all indexes to the right of the initial index
                for (int j = i + 1; j <= arr.Length - 1; j++)
                {
                    int nextNum = arr[j];

                    if (currentNum <= nextNum)
                    {
                        isTopInteger = false;
                        break;
                    }
                }

                if (isTopInteger)
                {
                    topIntegers[topIntegersIndex] = currentNum;
                    topIntegersIndex++;
                }
            }

            for (int i = 0; i < topIntegersIndex; i++)
            {
                int currentTopInteger = topIntegers[i];
                Console.Write($"{currentTopInteger} ");
            }

        }
    }
}