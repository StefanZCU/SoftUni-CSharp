using System;
using System.Linq;

namespace _01._Day_of_Week
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] dayOfWeek = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            int num = int.Parse(Console.ReadLine());

            if (num <= 7 && num > 0)
            {
                Console.WriteLine(dayOfWeek[num - 1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}

