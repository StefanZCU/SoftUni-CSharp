using System;

namespace _01._Old_Books
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bookNeeded = Console.ReadLine();
            int numberOfBooks = 0;

            while (true)
            {
                string bookFound = Console.ReadLine();
                numberOfBooks++;


                if (bookFound == bookNeeded)
                {
                    Console.WriteLine($"You checked {numberOfBooks - 1} books and found it.");
                    break;
                }

                if (bookFound == "No More Books")
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {numberOfBooks - 1} books.");
                    break;
                }


            }
        }
    }
}
