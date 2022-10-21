using System;

namespace _02._Print_Numbers_in_Reverse_Order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int[] arr = new int[num];

            for (int i = 0; i < num; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());

            }

            Array.Reverse(arr);

            Console.WriteLine(String.Join(" ", arr));
        }
    }
}
