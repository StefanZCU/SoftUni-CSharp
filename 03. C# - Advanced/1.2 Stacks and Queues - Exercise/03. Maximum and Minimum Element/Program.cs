int n = int.Parse(Console.ReadLine());

Stack<int> numbers = new Stack<int>();

for (int i = 0; i < n; i++)
{
    int[] command = Console.ReadLine().Split().Select(int.Parse).ToArray();

    int num = command[0];

    if (num == 1)
    {
        numbers.Push(command[1]);
    }
    else if (num == 2)
    {
        numbers.Pop();
    }
    else if (num == 3)
    {
        if (numbers.Count != 0)
        {
            Console.WriteLine(numbers.Max());
        }
    }
    else if (num == 4)
    {
        if (numbers.Count != 0)
        {
            Console.WriteLine(numbers.Min());
        }
    }
}

Console.WriteLine(string.Join(", ", numbers));
