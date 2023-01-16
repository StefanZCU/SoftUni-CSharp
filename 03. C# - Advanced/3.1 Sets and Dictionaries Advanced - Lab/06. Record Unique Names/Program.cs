HashSet<string> names = new HashSet<string>();
int numCycles = int.Parse(Console.ReadLine());

for (int i = 0; i < numCycles; i++)
{
    string name = Console.ReadLine();
    names.Add(name);
}

foreach (var name in names)
{
    Console.WriteLine(name);
}