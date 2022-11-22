using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> allGuests = new HashSet<string>();
            HashSet<string> vipGuests = new HashSet<string>();

            string command;
            while ((command = Console.ReadLine()) != "PARTY")
            {
                allGuests.Add(command);
            }

            while ((command = Console.ReadLine()) != "END")
            {
                if (allGuests.Contains(command))
                {
                    allGuests.Remove(command);
                }
            }

            Console.WriteLine(allGuests.Count);

            foreach (var guest in allGuests)
            {
                if (char.IsDigit(guest[0]))
                {
                    vipGuests.Add(guest);
                }
            }

            foreach (var vip in vipGuests)
            {
                allGuests.Remove(vip);
                Console.WriteLine(vip);
            }

            foreach (var guest in allGuests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
