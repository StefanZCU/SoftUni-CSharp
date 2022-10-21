using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int[] bombNum = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int originalCount = numList.Count;

            for (int i = 0; i < numList.Count; i++)
            {
                if (numList[i] == bombNum[0])
                {
                    int originalJ = i - bombNum[1];

                    if (originalJ < 0)
                    {
                        originalJ = 0;
                    }

                    for (int j = originalJ; j <= (bombNum[1] * 2) + originalJ; j++)
                    {
                        if (originalJ >= numList.Count)
                        {
                            break;
                        }
                        else
                        {
                            numList.RemoveAt(originalJ);
                        }
                        
                    }

                    i = 0;
                }
            }

            int sum = 0;

            foreach (int item in numList)
            {
                sum += item;
            }

            Console.WriteLine(sum);
        }
    }
}
