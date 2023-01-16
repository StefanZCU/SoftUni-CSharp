Dictionary<string, Dictionary<string, int>> userPoints = new Dictionary<string, Dictionary<string, int>>();
Dictionary<string, int> participantsPerLanguage = new Dictionary<string, int>();

string command;
while ((command = Console.ReadLine()) != "exam finished")
{
    string[] input = command.Split("-", StringSplitOptions.RemoveEmptyEntries);

    string username = input[0];

    if (input.Length == 3)
    {
        string language = input[1];
        int points = int.Parse(input[2]);


        if (!participantsPerLanguage.ContainsKey(language))
        {
            participantsPerLanguage.Add(language, 0);
        }
        
        if (!userPoints.ContainsKey(username))
        {
            userPoints.Add(username, new Dictionary<string, int>());
        }

        if (!userPoints[username].ContainsKey(language))
        {
            userPoints[username].Add(language, points);
        }

        if (userPoints[username][language] < points)
        {
            userPoints[username][language] = points;
        }

        participantsPerLanguage[language]++;
    }
    else if (input.Length == 2)
    {
        if (userPoints.ContainsKey(username))
        {
            userPoints.Remove(username);
        }
    }
}

Console.WriteLine("Results:");
foreach (var user in userPoints.OrderByDescending(x => x.Value.Values.Max()).ThenBy(x => x.Key))
{
    Console.WriteLine($"{user.Key} | {user.Value.Values.Max()}");
}

Console.WriteLine("Submissions:");
foreach (var language in participantsPerLanguage.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
{
    Console.WriteLine($"{language.Key} - {language.Value}");
}
