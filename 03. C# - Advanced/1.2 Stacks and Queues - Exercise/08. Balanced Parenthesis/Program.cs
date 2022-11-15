using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] parenthesis = input.ToCharArray();

            Stack<char> openBrackets = new Stack<char>();
            bool flag = true;

            foreach (var bracket in parenthesis)
            {
                if (bracket == '(')
                {
                    openBrackets.Push(bracket);
                }
                else if (bracket == '[')
                {
                    openBrackets.Push(bracket);
                }
                else if (bracket == '{')
                {
                    openBrackets.Push(bracket);
                }

                if (openBrackets.Count > 0)
                {
                    if (bracket == ')')
                    {
                        if (openBrackets.Peek() == '(')
                        {
                            openBrackets.Pop();
                        }
                        else
                        {
                            Console.WriteLine("NO");
                            flag = false;
                            break;
                        }
                    }
                    else if (bracket == ']')
                    {
                        if (openBrackets.Peek() == '[')
                        {
                            openBrackets.Pop();
                        }
                        else
                        {
                            Console.WriteLine("NO");
                            flag = false;
                            break;
                        }
                    }
                    else if (bracket == '}')
                    {
                        if (openBrackets.Peek() == '{')
                        {
                            openBrackets.Pop();
                        }
                        else
                        {
                            Console.WriteLine("NO");
                            flag = false;
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("NO");
                    flag = false;
                    break;
                }
            }

            if (flag && openBrackets.Count == 0)
            {
                Console.WriteLine("YES");
            }

        }
    }
}
