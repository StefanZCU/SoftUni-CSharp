using System;
using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string regexPattern = @"[@][#]+(?<product>[A-Z][A-Za-z0-9]{4,}[A-Z])[@][#]+";

            int numBarcodes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numBarcodes; i++)
            {
                string barcode = Console.ReadLine();

                Match match = Regex.Match(barcode, regexPattern);

                if (!match.Success)
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }
                else
                {
                    string productGroup = string.Empty;

                    for (int j = 0; j < match.Groups["product"].Value.Length; j++)
                    {
                        char currentChar = match.Groups["product"].Value[j];

                        if (char.IsDigit(currentChar))
                        {
                            productGroup += currentChar;
                        }
                    }

                    if (productGroup.Length == 0)
                    {
                        Console.WriteLine("Product group: 00");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: {productGroup}");
                    }
                }
            }
        }
    }
}
