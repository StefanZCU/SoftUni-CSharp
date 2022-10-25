using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Numerics;

namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger sum = n;

            for (int i = n - 1; i > 1; i--)
            {
                sum *= i;
            }

            Console.WriteLine(sum);
        }
    }
}