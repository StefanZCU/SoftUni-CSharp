using System;
using System.Numerics;

namespace _03._Exact_Sum_of_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            decimal sum = 0.0m;

            for (int i = 0; i < n; i++)
            {
                decimal num = decimal.Parse(Console.ReadLine());

                sum += num;
            }


            if (sum % 1 == 0)
            {
                Console.WriteLine(Convert.ToInt64(sum));
            }
            else
            {
                Console.WriteLine(sum);
            }
            
        }
    }
}
