using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> contestants = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> participants = new Dictionary<string, int>();
            List<string> contestantsToRemove = new List<string>();

            string command;
            while ((command = Console.ReadLine()) != "exam finished")
            {
                string[] input = command
                    .Split("-", StringSplitOptions.RemoveEmptyEntries);

                string username = input[0];
                string language = input[1];


                if (language != "banned" && !participants.ContainsKey(language))
                {
                    participants.Add(language, 1);
                }
                else if (language != "banned")
                {
                    participants[language]++;
                }

                if (!contestants.ContainsKey(username) && language != "banned")
                {
                    int points = int.Parse(input[2]);

                    contestants.Add(username, new Dictionary<string, int>());
                    contestants[username].Add(language, points);
                }

                if (!contestants[username].ContainsKey(language) && language != "banned")
                {
                    int points = int.Parse(input[2]);
                    contestants[username].Add(language, points);
                }


                if (language != "banned" && contestants[username].ContainsKey(language) 
                                         && input.Length > 2 
                                         && contestants[username][language] < int.Parse(input[2]))
                {
                    int points = int.Parse(input[2]);
                    contestants[username][language] = points;
                }

                if (language == "banned" && !contestantsToRemove.Contains(username))
                {
                    contestantsToRemove.Add(username);
                }
            }

            foreach (var contestant in contestantsToRemove)
            {
                contestants.Remove(contestant);
            }

            if (contestants.Count > 0)
            {
                Console.WriteLine("Results:");

                foreach (var studentName in contestants
                             .OrderByDescending(x => x.Value.Values.Max())
                             .ThenBy(y => y.Key))
                {
                    Console.WriteLine($"{studentName.Key} | {studentName.Value.Values.Max()}");
                }
            }

            if (participants.Count > 0)
            {
                Console.WriteLine("Submissions:");

                foreach (var language in participants
                             .OrderByDescending(x => x.Value)
                             .ThenBy(y => y.Key))
                {
                    Console.WriteLine($"{language.Key} - {language.Value}");
                }
            }
            
        }
    }
}
