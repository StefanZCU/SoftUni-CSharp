using System;

namespace _01._Encrypt__Sort_and_Print_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] names = new string[n];
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                names[i] = name;
            }

            int[] numbers = new int[n];

            for (int j = 0; j < n; j++)
            {
                sum = 0;

                char[] splitNames = names[j].ToCharArray();

                for (int k = 0; k < splitNames.Length; k++)
                {
                    switch (splitNames[k])
                    {
                        case 'a':
                        case 'e':
                        case 'i':
                        case 'o':
                        case 'u':
                        case 'A':
                        case 'E':
                        case 'I':
                        case 'O':
                        case 'U':

                            sum += splitNames[k] * splitNames.Length;

                            break;


                        default:

                            sum += splitNames[k] / splitNames.Length;

                            break;
                    }
                }

                numbers[j] = sum;
            }

            Array.Sort(numbers);

            foreach (int item in numbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
