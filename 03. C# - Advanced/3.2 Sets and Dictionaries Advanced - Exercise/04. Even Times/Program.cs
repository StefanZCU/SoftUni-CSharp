int numLines = int.Parse(Console.ReadLine());
Dictionary<int, int> numbers = new Dictionary<int, int>();

for (int i = 0; i < numLines; i++)
{
    int currNum = int.Parse(Console.ReadLine());

    if (!numbers.ContainsKey(currNum))
    {
        numbers.Add(currNum, 0);
    }

    numbers[currNum]++;
}

foreach (var number in numbers)
{
    if (number.Value % 2 == 0)
    {
        Console.WriteLine(number.Key);
    }
}