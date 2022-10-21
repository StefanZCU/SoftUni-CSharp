using System;

namespace _01._Smallest_of_Three_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int[] intArray = new int[] {num1, num2, num3};

            int result = GetHighestNum(intArray);
            Console.WriteLine(result);
        }

        static int GetHighestNum(int[] intArray)
        {
            Array.Sort(intArray);

            return intArray[0];
        }
    }
}
