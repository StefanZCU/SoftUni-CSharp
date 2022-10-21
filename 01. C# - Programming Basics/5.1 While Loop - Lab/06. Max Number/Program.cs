using System;

namespace _06._Max_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bigNum = int.MinValue;

            while (true)
            {
                string num = Console.ReadLine();
                

                if (num == "Stop")
                {
                    Console.WriteLine(bigNum);
                    break;
                }

                int num1 = int.Parse(num);

                if (num1 > bigNum)
                {
                    bigNum = num1;
                }
            }
        }
    }
}
