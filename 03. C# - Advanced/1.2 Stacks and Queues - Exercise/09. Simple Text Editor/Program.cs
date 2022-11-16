using System;
using System.Collections;
using System.Collections.Generic;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            //stack of queues

            Queue<char> text = new Queue<char>();

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();

                if (cmdArgs[0] == "1")
                {
                    for (int j = 0; j < cmdArgs[1].Length; j++)
                    {
                        text.Enqueue(cmdArgs[1][j]);
                    }
                }
                else if (cmdArgs[0] == "2")
                {
                    
                }
                else if (cmdArgs[0] == "3")
                {
                    
                }
                else if (cmdArgs[0] == "4")
                {
                    
                }
            }
        }
    }
}
