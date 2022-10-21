using System;
using System.Linq;

namespace _11._Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] input = command.Split().ToArray();

                if (input[0] == "exchange")
                {
                    if (int.Parse(input[1]) >= arr.Length || int.Parse(input[1]) < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else if (true)
                    {
                        GetExchangedArray(arr, int.Parse(input[1])); // rearranges array and stores in newArr
                    }
                }

                if (input[0] == "max" || input[0] == "min")
                {
                    if (OddEvenChecker(arr, input[1])) // if true, found min/max odd/even
                    {
                        switch (input[0])
                        {
                            case "max":
                                switch (input[1])
                                {
                                    case "even":

                                        Console.WriteLine(GetMaxEven(arr));

                                        break;

                                    case "odd":

                                        Console.WriteLine(GetMaxOdd(arr));

                                        break;

                                    default:
                                        break;
                                }
                                break;

                            case "min":
                                switch (input[1])
                                {
                                    case "even":

                                        Console.WriteLine(GetMinEven(arr));

                                        break;

                                    case "odd":

                                        Console.WriteLine(GetMinOdd(arr));

                                        break;

                                    default:
                                        break;
                                }
                                break;

                            default:

                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No matches");
                    }

                }

                if (input[0] == "first")
                {
                    if (int.Parse(input[1]) > arr.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else if (!OddEvenChecker(arr, input[2]))
                    {
                        Console.WriteLine("[]");
                    }
                    else if (input[2] == "even")
                    {
                        GetFirstEven(arr, int.Parse(input[1]));
                    }
                    else if (input[2] == "odd")
                    {
                        GetFirstOdd(arr, int.Parse(input[1]));
                    }
                }

                if (input[0] == "last")
                {
                    if (int.Parse(input[1]) > arr.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else if (!OddEvenChecker(arr, input[2]))
                    {
                        Console.WriteLine("[]");
                    }
                    else if (input[2] == "even")
                    {
                        GetLastEven(arr, int.Parse(input[1]));
                    }
                    else if (input[2] == "odd")
                    {
                        GetLastOdd(arr, int.Parse(input[1]));
                    }
                }
            }

            Console.WriteLine($"[{String.Join(", ", arr)}]");

        }

        static void GetExchangedArray(int[] arr, int index)
        {
            for (int j = 0; j <= index; j++)
            {
                int firstEl = arr[0];

                for (int i = 1; i < arr.Length; i++)
                {
                    arr[i - 1] = arr[i];
                }

                arr[arr.Length - 1] = firstEl;
            }
        }

        static bool OddEvenChecker(int[] arr, string input)
        {
            if (input == "odd")
            {
                foreach (int item in arr)
                {
                    if (item % 2 == 1)
                    {
                        return true;
                    }
                }
            }
            else if (input == "even")
            {
                foreach (int item in arr)
                {
                    if (item % 2 == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static int GetMaxEven(int[] arr)
        {
            int maxEven = int.MinValue;
            int maxEvenIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    if (arr[i] == maxEven)
                    {
                        maxEvenIndex = i;
                    }
                    else if (arr[i] > maxEven)
                    {
                        maxEven = arr[i];
                        maxEvenIndex = i;
                    }
                }

            }

            return maxEvenIndex;
        }

        static int GetMaxOdd(int[] arr)
        {
            int maxOdd = int.MinValue;
            int maxOddIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 1)
                {
                    if (arr[i] == maxOdd)
                    {
                        maxOddIndex = i;
                    }
                    else if (arr[i] > maxOdd)
                    {
                        maxOdd = arr[i];
                        maxOddIndex = i;
                    }
                }
            }

            return maxOddIndex;
        }

        static int GetMinEven(int[] arr)
        {
            int minEven = int.MaxValue;
            int minEvenIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    if (arr[i] == minEven)
                    {
                        minEvenIndex = i;
                    }
                    else if (arr[i] < minEven)
                    {
                        minEven = arr[i];
                        minEvenIndex = i;
                    }
                }
            }

            return minEvenIndex;
        }

        static int GetMinOdd(int[] arr)
        {
            int minOdd = int.MaxValue;
            int minOddIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 1)
                {
                    if (arr[i] == minOdd)
                    {
                        minOddIndex = i;
                    }
                    else if (arr[i] < minOdd)
                    {
                        minOdd = arr[i];
                        minOddIndex = i;
                    }
                }
            }

            return minOddIndex;
        }

        static void GetFirstEven(int[] arr, int count)
        {
            string numbers = string.Empty;
            int foundEven = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (foundEven < count)
                {
                    if (arr[i] % 2 == 0)
                    {
                        numbers += arr[i] + " ";
                        foundEven++;
                    }
                    else
                    {
                        continue;
                    }
                }
                
            }

            int[] newArr = numbers.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Console.WriteLine($"[{String.Join(", ", newArr)}]");

        }

        static void GetFirstOdd(int[] arr, int count)
        {
            string numbers = string.Empty;
            int foundOdd = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (foundOdd < count)
                {
                    if (arr[i] % 2 == 1)
                    {
                        numbers += arr[i] + " ";
                        foundOdd++;
                    }
                    else
                    {
                        continue;
                    }
                }

            }

            int[] newArr = numbers.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Console.WriteLine($"[{String.Join(", ", newArr)}]");

        }

        static void GetLastEven(int[] arr, int count)
        {
            string numbers = string.Empty;
            int foundEven = 0;

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (foundEven < count)
                {
                    if (arr[i] % 2 == 0)
                    {
                        numbers += arr[i] + " ";
                        foundEven++;
                    }
                    else
                    {
                        continue;
                    }
                }

            }

            int[] newArr = numbers.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Console.WriteLine($"[{String.Join(", ", newArr.Reverse())}]");
        }

        static void GetLastOdd(int[] arr, int count)
        {
            string numbers = string.Empty;
            int foundOdd = 0;

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (foundOdd < count)
                {
                    if (arr[i] % 2 == 1)
                    {
                        numbers += arr[i] + " ";
                        foundOdd++;
                    }
                    else
                    {
                        continue;
                    }
                }

            }

            int[] newArr = numbers.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Console.WriteLine($"[{String.Join(", ", newArr.Reverse())}]");
        }
    }
}
