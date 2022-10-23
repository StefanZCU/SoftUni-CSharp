using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _03_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> bookShelf = Console.ReadLine().Split("&").ToList();

            string command;
            while ((command = Console.ReadLine()) != "Done")
            {
                string[] input = command.Split(" | ");

                if (input[0] == "Add Book")
                {
                    if (!bookShelf.Contains(input[1]))
                    {
                        bookShelf.Insert(0, input[1]);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (input[0] == "Take Book")
                {
                    if (bookShelf.Contains(input[1]))
                    {
                        bookShelf.Remove(input[1]);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (input[0] == "Swap Books")
                {
                    if (bookShelf.Contains(input[1]) && bookShelf.Contains(input[2]))
                    {
                        for (int i = 0; i < bookShelf.Count; i++)
                        {
                            if (bookShelf[i] == input[1])
                            {
                                bookShelf[i] = input[2];
                            }
                            else if (bookShelf[i] == input[2])
                            {
                                bookShelf[i] = input[1];
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (input[0] == "Insert Book")
                {
                    if (!bookShelf.Contains(input[1]))
                    {
                        bookShelf.Add(input[1]);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (input[0] == "Check Book")
                {
                    if (int.Parse(input[1]) >= 0 && int.Parse(input[1]) < bookShelf.Count)
                    {
                        Console.WriteLine(bookShelf[int.Parse(input[1])]);
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            Console.WriteLine(String.Join(", ", bookShelf));
        }
    }
}