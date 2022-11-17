using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<string> textVersions = new Stack<string>();
            textVersions.Push("");
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();

                if (cmdArgs[0] == "1")
                {
                    sb.Append(cmdArgs[1]);
                    textVersions.Push(sb.ToString());
                }
                else if (cmdArgs[0] == "2")
                {
                    for (int j = 0; j < int.Parse(cmdArgs[1]); j++)
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }

                    textVersions.Push(sb.ToString());
                }
                else if (cmdArgs[0] == "3")
                {
                    Console.WriteLine(sb[int.Parse(cmdArgs[1]) - 1]);
                }
                else if (cmdArgs[0] == "4")
                {
                    sb.Clear();
                    textVersions.Pop();
                    sb.Append(textVersions.Peek());
                }
            }
        }
    }
}
