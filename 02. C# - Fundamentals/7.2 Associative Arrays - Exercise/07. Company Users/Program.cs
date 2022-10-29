using System;
using System.Collections.Generic;

namespace _07._Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> idPerCompany = new Dictionary<string, List<string>>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string companyName = input[0];
                string employeeId = input[1];

                if (!idPerCompany.ContainsKey(companyName))
                {
                    idPerCompany.Add(companyName, new List<string>());
                    idPerCompany[companyName].Add(employeeId);
                }
                else
                {
                    if (idPerCompany[companyName].Contains(employeeId))
                    {
                        
                    }
                    else
                    {
                        idPerCompany[companyName].Add(employeeId);
                    }
                }
            }

            foreach (var company in idPerCompany)
            {
                Console.WriteLine($"{company.Key}");
                foreach (var id in company.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}
