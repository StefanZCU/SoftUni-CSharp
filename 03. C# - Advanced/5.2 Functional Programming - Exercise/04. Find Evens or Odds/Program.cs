int[] rangeNum = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

string oddOrEven = Console.ReadLine();

List<int> newNumbers = new List<int>();

for(int i = rangeNum[0]; i <= rangeNum[1]; i++)
{
    if (oddOrEven == "odd")
    {
        if (NumberChecker(i, n => n % 2 != 0))
        {
            newNumbers.Add(i);
        }
    }
    else if (oddOrEven == "even")
    {
        if (NumberChecker(i, n => n % 2 == 0))
        {
            newNumbers.Add(i);
        }
    }
    else
    {
        newNumbers.Add(i);
    }
}

Console.WriteLine(string.Join(" ", newNumbers));

bool NumberChecker(int number, Predicate<int> oddEven)
{
    return oddEven(number);
}