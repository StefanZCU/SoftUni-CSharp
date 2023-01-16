Dictionary<string, string> contestPassword = new Dictionary<string, string>();
Dictionary<string, Dictionary<string, int>> pointsPerStudent = new Dictionary<string, Dictionary<string, int>>();

string command;
while ((command = Console.ReadLine()) != "end of contests")
{
    string[] input = command.Split(":", StringSplitOptions.RemoveEmptyEntries);

    contestPassword.Add(input[0], input[1]);
}

while ((command = Console.ReadLine()) != "end of submissions")
{
    string[] input = command.Split("=>", StringSplitOptions.RemoveEmptyEntries);

    string contest = input[0];
    string password = input[1];
    string username = input[2];
    int points = int.Parse(input[3]);

    if (contestPassword.ContainsKey(contest) && contestPassword[contest] == password)
    {
        if (!pointsPerStudent.ContainsKey(username))
        {
            pointsPerStudent.Add(username, new Dictionary<string, int>());
        }

        if (!pointsPerStudent[username].ContainsKey(contest))
        {
            pointsPerStudent[username].Add(contest, points);
        }

        if (pointsPerStudent[username][contest] < points)
        {
            pointsPerStudent[username][contest] = points;
        }
    }
}

int mostPoints = 0;
string bestStudent = string.Empty;

foreach (var student in pointsPerStudent)
{
    if (student.Value.Values.Sum() > mostPoints)
    {
        bestStudent = student.Key;
        mostPoints = student.Value.Values.Sum();
    }
}

Console.WriteLine($"Best candidate is {bestStudent} with total {mostPoints} points.");
Console.WriteLine("Ranking:");

foreach (var student in pointsPerStudent.OrderBy(x => x.Key))
{
    Console.WriteLine(student.Key);

    foreach (var contest in student.Value.OrderByDescending(x => x.Value))
    {
        Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
    }
}

