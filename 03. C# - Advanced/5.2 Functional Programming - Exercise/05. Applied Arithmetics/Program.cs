int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

string command;
while ((command = Console.ReadLine()) != "end")
{
    if (command == "add")
    {
        Calculator(numbers, x => x + 1);
    }
    else if (command == "multiply")
    {
        Calculator(numbers, x => x * 2);
    }
    else if (command == "subtract")
    {
        Calculator(numbers, x => x - 1);
    }
    else if (command == "print")
    {
        Console.WriteLine(string.Join(" ", numbers));
    }
}

void Calculator(int[] numbers, Func<int, int> op)
{
    for (int i = 0; i < numbers.Length; i++)
    {
        numbers[i] = op(numbers[i]);
    }
}