using System;

namespace _04._Tribonacci_Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            GetTribonacci(num);
        }

        static void GetTribonacci(int num)
        {
            int sum1 = 1;
            int sum2 = 0;
            int sum3 = 0;

            for (int i = 0; i < num; i++)
            {
                    int result = sum1 + sum2 + sum3;
                    Console.Write($"{result} ");
                    sum1 = sum2;
                    sum2 = sum3;
                    sum3 = result;
            }
        }
    }
}