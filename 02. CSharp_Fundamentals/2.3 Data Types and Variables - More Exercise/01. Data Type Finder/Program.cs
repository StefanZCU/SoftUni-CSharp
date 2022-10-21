using System;
using System.Globalization;

namespace _01._Data_Type_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                
                if (input == "END")
                {
                    break;
                }

                string finalType = "";

                if (!string.IsNullOrEmpty(input))
                {
                    int tryInt;
                    double tryDouble;
                    char tryChar;
                    bool tryBool;

                    if (Int32.TryParse(input, out tryInt))
                    {
                        finalType = "integer";
                    }
                    else if (Double.TryParse(input, out tryDouble))
                    {
                        finalType = "floating point";
                    }
                    else if (Char.TryParse(input, out tryChar))
                    {
                        finalType = "character";
                    }
                    else if (Boolean.TryParse(input, out tryBool))
                    {
                        finalType = "boolean";
                    }
                    else
                    {
                        finalType = "string";
                    }
                }
                Console.WriteLine($"{input} is {finalType} type");
            }
        }
    }
}
