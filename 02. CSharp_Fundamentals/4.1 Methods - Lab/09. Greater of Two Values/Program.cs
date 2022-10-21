using System;

namespace _09._Greater_of_Two_Values
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();

            if (dataType == "int")
            {
                int result = GetMax(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
                Console.WriteLine(result);
            }
            else if (dataType == "char")
            {
                char result = GetMax(char.Parse(Console.ReadLine()), char.Parse(Console.ReadLine()));
                Console.WriteLine(result);
            }
            else if (dataType == "string")
            {
                string result = GetMax(Console.ReadLine(), Console.ReadLine());
                Console.WriteLine(result);
            }
        }

        static int GetMax(int input1, int input2)
        {
            if (input1 > input2)
            {
                return input1;
            }
                return input2;
            
        }

        static char GetMax(char input1, char input2)
        {
            if (input1 > input2)
            {
                return input1;
            }
                return input2;
            
        }

        static string GetMax(string input1, string input2)
        {
            int result = input1.CompareTo(input2);

            if (result > 0)
            {
                return input1;
            }

            return input2;
            
        }
    }
}
