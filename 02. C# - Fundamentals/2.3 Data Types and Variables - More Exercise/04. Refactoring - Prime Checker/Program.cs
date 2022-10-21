using System;

namespace _04._Refactoring___Prime_Checker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 2; i <= num; i++)
            {
                bool checker = true;

                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        checker = false;
                        break;
                    }
                }

                string checkerString = checker.ToString();
                Console.WriteLine($"{i} -> {checkerString.ToLower()}");
            }

        }
    }
}
