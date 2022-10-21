using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _02._Shoot_for_the_Win
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numSequence = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] shots = new int[numSequence.Count];

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                int shot = int.Parse(command);

                if (shot >= 0 && shot < numSequence.Count)
                {
                    if (shots[shot] == 0)
                    {
                        int currentNum = numSequence[shot];
                        numSequence[shot] = -1;
                        shots[shot] = 1;

                        for (int i = 0; i < numSequence.Count; i++)
                        {
                            if (shots[i] == 1)
                            {
                                continue;
                            }
                            else if (numSequence[i] <= currentNum)
                            {
                                numSequence[i] += currentNum;
                            }
                            else if (numSequence[i] > currentNum)
                            {
                                numSequence[i] -= currentNum;
                            }
                        }

                    }
                    else
                    {
                        continue;
                    }
                }

            }

            int count = 0;

            foreach (int item in shots)
            {
                if (item == 1)
                {
                    count++;
                }
            }

            Console.WriteLine($"Shot targets: {count} -> {string.Join(" ", numSequence)}");
        }
    }
}