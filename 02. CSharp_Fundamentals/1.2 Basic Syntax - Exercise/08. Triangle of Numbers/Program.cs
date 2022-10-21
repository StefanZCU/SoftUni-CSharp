using System;

namespace _08._Triangle_of_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i <= num; i++)
            {
                for (int j = 1; j <= num; j++)
                {
                    if (j <= i)
                    {
                        Console.Write($"{i} ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
