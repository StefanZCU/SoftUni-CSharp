using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> list2 = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> newList = new List<int>();

            int originalCountlist1 = list1.Count;
            int originalCountlist2 = list2.Count;   

            if (list1.Count <= list2.Count)
            {
                for (int i = 0; i < originalCountlist1; i++)
                {
                    newList.Add(list1[0]);
                    newList.Add(list2[0]);
                    list1.Remove(list1[0]);
                    list2.Remove(list2[0]);
                }

                if (list2.Count > list1.Count)
                {
                    foreach (int item in list2)
                    {
                        newList.Add(item);
                    }
                }

            }
            else
            {
                for (int i = 0; i < originalCountlist2; i++)
                {
                    newList.Add(list1[0]);
                    newList.Add(list2[0]);
                    list1.Remove(list1[0]);
                    list2.Remove(list2[0]);
                }

                if (list1.Count > list2.Count)
                {
                    foreach (int item in list1)
                    {
                        newList.Add(item);
                    }
                }
            }

            Console.WriteLine(String.Join(" ", newList));
        }
    }
}
