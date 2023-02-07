﻿namespace P04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            string[] elements = Console.ReadLine().Split();

            foreach (string element in elements)
            {
                try
                {
                    int currentNum = int.Parse(element);
                    sum += currentNum;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{element}' is in wrong format!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{element}' is out of range!");
                }
                finally
                {
                    Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}