using System;
using System.Collections.Generic;

namespace _04._SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numCmds = int.Parse(Console.ReadLine());

            Dictionary<string, string> licensePlateForUser = new Dictionary<string, string>();
            
            for (int i = 0; i < numCmds; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = input[0];

                if (action == "register")
                {
                    string username = input[1];
                    string licensePlate = input[2];

                    if (!licensePlateForUser.ContainsKey(username))
                    {
                        licensePlateForUser.Add(username, licensePlate);
                        Console.WriteLine($"{username} registered {licensePlate} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateForUser[username]}");
                    }
                }
                else
                {
                    string username = input[1];

                    if (licensePlateForUser.ContainsKey(username))
                    {
                        licensePlateForUser.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                }
            }

            foreach (var user in licensePlateForUser)
            {
                Console.WriteLine($"{user.Key} => {user.Value}"); 
            }
        }
    }
}
