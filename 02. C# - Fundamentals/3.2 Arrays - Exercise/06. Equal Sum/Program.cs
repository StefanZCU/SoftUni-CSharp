using System;
using System.Linq;


namespace _06._Equal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* 1. read input, put it into an array
             * 2. make a loop that goes through all numbers beside [i].
             * 3. print the index where the conditions are satisfied.*/

            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int leftSum = 0;
            int rightSum = 0;
            bool flag = true;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i == j)
                    {
                        j++;

                        if (j == nums.Length)
                        {
                            rightSum = 0;
                            break;
                        }

                        else if (i == 0)
                        {
                            leftSum = 0;
                        }
                    }

                    if (j > i)
                    {
                        rightSum += nums[j];
                    }
                    else if (j < i)
                    {
                        leftSum += nums[j];
                    }

                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    flag = false;
                    break;
                }
                else
                {
                    leftSum = 0;
                    rightSum = 0;
                }
            }

            if (flag)
            {
                Console.WriteLine("no");
            }
             
        }
    }
}
