using System;

namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int[] passengers = new int[num];
            int sum = 0;

            for (int i = 0; i < passengers.Length; i++)
            {
                int print = int.Parse(Console.ReadLine());
                sum += print;
                passengers[i] = print;
            }

            Console.WriteLine(String.Join(" ", passengers));
            Console.WriteLine(sum);
        }
    }
}
