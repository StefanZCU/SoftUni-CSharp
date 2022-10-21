using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* 1. read array from console.
             * 2. loop through all numbers and find a sequence (nums[i] == nums[j])
             * 3. if you find a sequence, add it to leftMost variable.
             * 4. if you find another sequence, compare the two seqences and see which one has a lower index.
             */

            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int mainNum = 0;
            int tempNum = 0;

            int numSequences = 0;
            int tempSequences = 0;

            bool flag = false;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i; j < nums.Length; j++)
                {
                    if (nums[j] == nums[i])
                    {
                        tempSequences++;
                        tempNum = nums[j];
                    }
                    else
                    {
                        tempSequences = 0;
                        tempNum = 0;
                        break;
                    }

                    if (tempSequences > numSequences)
                    {
                        numSequences = tempSequences;
                        mainNum = tempNum;
                    }

                    if (j == nums.Length - 1)
                    {
                        flag = true;
                        break;
                    }
                }

                if (flag)
                {
                    break;
                }
            }

            if (numSequences > nums.Length)
            {
                numSequences = nums.Length;
            }

            for (int k = 1; k <= numSequences; k++)
            {
                Console.Write($"{mainNum} ");
            }
        }
    }
}
