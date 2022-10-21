using System;

namespace _10._Poke_Mon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int Y = int.Parse(Console.ReadLine());

            int pokeCount = 0;
            int newN = N;

            while (true)
            {
                newN = newN - M;
                pokeCount++;

                if (newN + newN == N && 0 < Y)
                {
                    newN = newN / Y;
                }

                if (newN < M)
                {
                    break;
                }
            }

            Console.WriteLine(newN);
            Console.WriteLine(pokeCount);
        }
    }
}
