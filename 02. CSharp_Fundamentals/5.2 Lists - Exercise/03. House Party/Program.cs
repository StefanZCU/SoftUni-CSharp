using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace _03._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numInput = int.Parse(Console.ReadLine());

            List<string> pplGoing = new List<string>();

            for (int i = 0; i < numInput; i++)
            {
                string[] input = Console.ReadLine().Split();

                if (input[2] == "going!")
                {
                    if (GetGoingToParty(pplGoing, input[0]))
                    {
                        pplGoing.Add(input[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{input[0]} is already in the list!");
                    }
                }
                else if (input[2] == "not")
                {
                    if (GetIsInList(pplGoing, input[0]))
                    {
                        pplGoing.Remove(input[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{input[0]} is not in the list!");
                    }
                }
            }

            foreach (string name in pplGoing)
            {
                Console.WriteLine(name);
            }
        }

        static bool GetGoingToParty(List<string> pplGoing, string name)
        {
            if (pplGoing.Contains(name))
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        static bool GetIsInList(List<string> pplGoing, string name)
        {
            if (pplGoing.Contains(name))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
