int n = int.Parse(Console.ReadLine());

string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

Func<string, int, bool> nameCheckerFunc = NameChecker;

string name = names.FirstOrDefault(s => nameCheckerFunc(s, n));

Console.WriteLine(name);

bool NameChecker(string s, int n)
{
    int sum = s.Sum(ch =>
    {
        return (int)ch;

    });

    return sum >= n;
}