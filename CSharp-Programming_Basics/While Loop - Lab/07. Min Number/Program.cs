using System;

namespace _07._Min_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int smallNum = int.MaxValue;

            while (true)
            {
                string num = Console.ReadLine();


                if (num == "Stop")
                {
                    Console.WriteLine(smallNum);
                    break;
                }

                int num1 = int.Parse(num);

                if (num1 < smallNum)
                {
                    smallNum = num1;
                }
            }
        }
    }
}
