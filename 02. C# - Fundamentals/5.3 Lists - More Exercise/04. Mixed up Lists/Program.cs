using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> list2 = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> finalResult = new List<int>();

            int highestNum = int.MinValue, lowestNum = int.MaxValue;
            int originalCount1 = list1.Count;
            int originalCount2 = list2.Count;

            if (list1.Count > list2.Count)
            {
                for (int i = 0; i < originalCount2; i++)
                {
                    finalResult.Insert(i, list1[0]);
                    finalResult.Insert(i, list2[0]);
                    list1.RemoveAt(0);
                    list2.RemoveAt(0);
                }

                finalResult.Sort();

                foreach (int item in list1)
                {
                    if (item < lowestNum)
                    {
                        lowestNum = item;
                    }
                    
                    if (item > highestNum)
                    {
                        highestNum = item;
                    }
                }

                foreach (int item in finalResult)
                {
                    if (item < highestNum && item > lowestNum)
                    {
                        Console.Write($"{item} ");
                    }
                }

            }
            else if (list1.Count < list2.Count)
            {
                for (int i = 0; i < originalCount1; i++)
                {
                    finalResult.Insert(i, list1[list1.Count - 1]);
                    finalResult.Insert(i, list2[list2.Count - 1]);
                    list1.RemoveAt(list1.Count - 1);
                    list2.RemoveAt(list2.Count - 1);
                }

                finalResult.Sort();

                foreach (int item in list2)
                {
                    if (item < lowestNum)
                    {
                        lowestNum = item;
                    }
                    
                    if (item > highestNum)
                    {
                        highestNum = item;
                    }
                }

                foreach (int item in finalResult)
                {
                    if (item < highestNum && item > lowestNum)
                    {
                        Console.Write($"{item} ");
                    }
                }
            }

        }
    }
}
