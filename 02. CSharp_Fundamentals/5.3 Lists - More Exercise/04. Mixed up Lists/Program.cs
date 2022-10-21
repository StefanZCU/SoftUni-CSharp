using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Mixed_up_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listOne = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> listTwo = Console.ReadLine().Split().Select(int.Parse).ToList();


            List<int> result = new List<int>();

            if (listOne.Count > listTwo.Count)
            {
                for (int i = 0; i < listOne.Count; i++)
                {
                    if (listOne.Count == 2)
                    {
                        break;
                    }

                    result.Insert(i, listOne[i]);
                    result.Insert(i, listTwo[listTwo.Count - 1]);
                    listOne.RemoveAt(i);
                    listTwo.RemoveAt(listTwo.Count - 1);
                }
            }
            else
            {

            }
        }
    }
}
