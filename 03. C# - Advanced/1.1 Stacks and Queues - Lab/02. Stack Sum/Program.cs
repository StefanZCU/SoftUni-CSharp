int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
Stack<int> numberStack = new Stack<int>(numbers);

string command;
while ((command = Console.ReadLine().ToLower()) != "end")
{
    string[] input = command.Split();

    if (input[0] == "add")
    {
        int firstNum = int.Parse(input[1]);
        int secondNum = int.Parse(input[2]);

        numberStack.Push(firstNum);
        numberStack.Push(secondNum);
    }
    else if (input[0] == "remove" && int.Parse(input[1]) <= numberStack.Count)
    {
        int numCount = int.Parse(input[1]);

        for (int i = 0; i < numCount; i++)
        {
            numberStack.Pop();
        }
    }
}

Console.WriteLine($"Sum: {numberStack.Sum()}");


