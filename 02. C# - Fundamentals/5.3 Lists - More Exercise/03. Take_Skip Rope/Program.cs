using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp4
{
    internal class Program
    {
        static (List<char>, List<int>) ExtractNumbersListFromMainList(List<char> list)
        {
            List<int> numbersList = new List<int>();

            int index = 0;

            while (index < list.Count)
            {
                if (list[index] >= 48 && list[index] <= 57)
                {
                    numbersList.Add(int.Parse(list[index].ToString()));
                    list.RemoveAt(index);
                }
                else
                {
                    index++;
                }
            }
            return (list, numbersList);
        }

        static (List<int>, List<int>) SplitNumbersListIntoTakeAndSkipLists(List<int> numbers)
        {
            List<int> take = new List<int>();
            List<int> skip = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    take.Add(numbers[i]);
                }
                else
                {
                    skip.Add(numbers[i]);
                }
            }
            return (take, skip);
        }

        static void Main()
        {
            List<char> mainList = Console.ReadLine().ToList();
            List<int> numbersList = new List<int>();
            (mainList, numbersList) = ExtractNumbersListFromMainList(mainList);

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();
            (takeList, skipList) = SplitNumbersListIntoTakeAndSkipLists(numbersList);

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < takeList.Count; i++)
            {
                // Taking chars from main list to result string
                for (int j = 0; j < takeList[i]; j++)
                {
                    if (mainList.Count > 0)
                    {
                        result.Append(mainList[0]);
                        mainList.RemoveAt(0);
                    }
                }

                if (i >= skipList.Count)
                {
                    break;
                }

                // Skipping chars from main list
                for (int j = 0; j < skipList[i]; j++)
                {
                    if (mainList.Count > 0)
                    {
                        mainList.RemoveAt(0);
                    }
                }
            }

            Console.WriteLine(result.ToString());
        
        }
    }
}
