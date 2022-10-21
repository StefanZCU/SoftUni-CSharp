using System;

namespace _02._Sum_Digits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();

            int tempNum = int.Parse(num);
            int sum = 0;

            for (int i = 0; i < num.Length; i++)
            {
                int newNum = tempNum % 10;
                sum += newNum;
                tempNum /= 10;
            }
            Console.WriteLine(sum);
        }
    }
}
