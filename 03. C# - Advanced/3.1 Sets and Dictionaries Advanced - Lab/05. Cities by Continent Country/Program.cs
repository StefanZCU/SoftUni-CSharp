Dictionary<string, Dictionary<string, List<string>>> continent = new Dictionary<string, Dictionary<string, List<string>>>();
int numCycles = int.Parse(Console.ReadLine());

for (int i = 0; i < numCycles; i++)
{
    string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (!continent.ContainsKey(input[0]))
    {
        continent.Add(input[0], new Dictionary<string, List<string>>());
    }

    if (!continent[input[0]].ContainsKey(input[1]))
    {
        continent[input[0]].Add(input[1], new List<string>());
    }

    continent[input[0]][input[1]].Add(input[2]);
}

foreach (var continentKVP in continent)
{
    Console.WriteLine($"{continentKVP.Key}:");

    foreach (var countryKVP in continentKVP.Value)
    {
        Console.WriteLine($"  {countryKVP.Key} -> {string.Join(", ", countryKVP.Value)}");
    }
}