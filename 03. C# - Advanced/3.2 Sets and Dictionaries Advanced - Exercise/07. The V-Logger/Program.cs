
Dictionary<string, VloggerStats> statsPerVlogger = new Dictionary<string, VloggerStats>();

string command;
while ((command = Console.ReadLine()) != "Statistics")
{
    string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string name = input[0];
    string action = input[1];

    if (!statsPerVlogger.ContainsKey(name) && action == "joined")
    {
        statsPerVlogger.Add(name, new VloggerStats());
    }

    string personToFollow = input[2];

    if (action == "followed" && statsPerVlogger.ContainsKey(name) && statsPerVlogger.ContainsKey(personToFollow))
    {
        if (!statsPerVlogger[name].following.Contains(personToFollow) && personToFollow != name)
        {
            statsPerVlogger[name].following.Add(personToFollow);
            statsPerVlogger[personToFollow].followers.Add(name);
        }
    }

}

Console.WriteLine($"The V-Logger has a total of {statsPerVlogger.Keys.Count} vloggers in its logs.");

int index = 1;

foreach (var vlogger in statsPerVlogger.OrderByDescending(x => x.Value.followers.Count).ThenBy(x => x.Value.following.Count))
{
    Console.WriteLine($"{index}. {vlogger.Key} : {vlogger.Value.followers.Count} followers, {vlogger.Value.following.Count} following");

    if (index == 1)
    {
        foreach (var follower in vlogger.Value.followers.OrderBy(x => x))
        {
            Console.WriteLine($"*  {follower}");
        }
    }
    
    index++;
}


class VloggerStats
{
    public List<string> following { get; set; } = new List<string>();
    public List<string> followers { get; set; } = new List<string>();

}
