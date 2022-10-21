using System;
using System.Linq;

namespace _08._Condense_Array_to_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int firstLength = nums.Length;

            for (int i = 0; i < firstLength - 1; i++)
            {
                int[] condensed = new int[nums.Length - 1];

                for (int j = 0; j < nums.Length - 1; j++)
                {
                    condensed[j] = nums[j] + nums[j + 1];
                }

                nums = condensed;
            }

            Console.WriteLine(nums[0]);
        }
    }
}
