Action<string> printNames = s => Console.WriteLine($"Sir {s}");

string[] names = Console.ReadLine().Split(" ");

foreach (var name in names)
{
    printNames(name);
}
