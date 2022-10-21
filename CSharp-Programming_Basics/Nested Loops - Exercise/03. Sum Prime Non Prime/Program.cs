using System;

namespace _03._Sum_Prime_Non_Prime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sumPrime = 0;
            int sumNonPrime = 0;

            while (true)
            {
                string n = Console.ReadLine();

                if (n == "stop")
                {
                    Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
                    Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrime}");
                    break;
                }

                int num = int.Parse(n);
                bool prime = true;

                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                }

                for (int i = 2; i <= Math.Sqrt(num); i++)
                {
                    if (num % i == 0)
                    {
                        prime = false;
                        break;
                    }
                }
                if ((prime) && (num >= 0))
                {
                    sumPrime += num;
                }
                else if ((prime == false) && (num >= 0))
                {
                    sumNonPrime += num;
                }
            }
        }
    }
}
