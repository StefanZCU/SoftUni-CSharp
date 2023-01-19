int endRange = int.Parse(Console.ReadLine());

List<int> dividers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

List<int> numbers = new List<int>();

for (int i = 1; i <= endRange; i++)
{
    numbers.Add(i);
}

foreach (var divider in dividers)
{
    Func<int, bool> filterFunc = x => x % divider == 0;

    numbers = numbers.Where(filterFunc).ToList();
}

Console.WriteLine(string.Join(" ", numbers));
