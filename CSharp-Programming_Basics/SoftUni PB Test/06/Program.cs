using System;

namespace _06_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int boundaryFirstNum = int.Parse(Console.ReadLine());
            int boundarySecondNum = int.Parse(Console.ReadLine());
            int boundaryThirdNum = int.Parse(Console.ReadLine());

            for (int i = 1; i <= boundaryFirstNum; i++)
            {
                for (int j = 1; j <= boundarySecondNum; j++)
                {
                    for (int k = 1; k <= boundaryThirdNum; k++)
                    {
                        if (i % 2 == 0)
                        {
                            if (j == 2 || j == 3 || j == 5 || j == 7)
                            {
                                if (k % 2 == 0)
                                {
                                    Console.WriteLine($"{i} {j} {k}");
                                }
                            }
                        }
                    }
                }
            }
        
        }
    }
}
