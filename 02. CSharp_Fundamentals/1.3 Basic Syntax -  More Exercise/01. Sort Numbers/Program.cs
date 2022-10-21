using System;

namespace _01._Sort_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[3];

            arr[0] = int.Parse(Console.ReadLine());
            arr[1] = int.Parse(Console.ReadLine());
            arr[2] = int.Parse(Console.ReadLine());

            Array.Sort(arr);
            Array.Reverse(arr);

            foreach (int item in arr)
            {
                Console.WriteLine(item);
            }

            
        }
    }
}
