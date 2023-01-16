int numNames = int.Parse(Console.ReadLine());

Dictionary<string, List<decimal>> gradesPerName = new Dictionary<string, List<decimal>>();

for (int i = 0; i < numNames; i++)
{
    string[] nameGrade = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (!gradesPerName.ContainsKey(nameGrade[0]))
    {
        gradesPerName.Add(nameGrade[0], new List<decimal>());
    }

    gradesPerName[nameGrade[0]].Add(decimal.Parse(nameGrade[1]));
}

foreach (var name in gradesPerName)
{
    Console.WriteLine($"{name.Key} -> {string.Join(" ", name.Value.ConvertAll(x => string.Format("{0:0.00}", x)))} (avg: {name.Value.Average():F2})");
}