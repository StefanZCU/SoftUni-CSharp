int numNames = int.Parse(Console.ReadLine());
HashSet<string> uniqueNames = new HashSet<string>();

for (int i = 0; i < numNames; i++)
{
    string name = Console.ReadLine();
    uniqueNames.Add(name);
}

foreach (var uniqueName in uniqueNames)
{
    Console.WriteLine(uniqueName);
}