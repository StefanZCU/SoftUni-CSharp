using System;

namespace _03._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int total = 0;

            while (true)
            {
                int newNum = int.Parse(Console.ReadLine());
                total += newNum;

                if (total >= number)
                {
                    Console.WriteLine(total);
                    break;
                }
            }
        }
    }
}
