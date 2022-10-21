using System;
using System.Linq;

namespace _04._Reverse_Array_of_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split().ToArray();

            Array.Reverse(arr);

            Console.WriteLine(String.Join(" ", arr));
                
        }
    }
}
