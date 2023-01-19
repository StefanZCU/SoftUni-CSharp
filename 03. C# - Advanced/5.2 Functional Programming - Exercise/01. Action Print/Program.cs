Action<string> printNames = s => Console.WriteLine(s);

string[] names = Console.ReadLine().Split(" ");

foreach (var name in names)
{
    printNames(name);
}