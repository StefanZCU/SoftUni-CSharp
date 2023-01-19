int nameLength = int.Parse(Console.ReadLine());

string[] names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Where(x => x.Length <= nameLength)
    .ToArray();

foreach (var name in names)
{
    Console.WriteLine(name);
}