string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

Queue<string> nameQueue = new Queue<string>(names);

int numPasses = int.Parse(Console.ReadLine());

while (nameQueue.Count != 1)
{
    for (int i = 1; i < numPasses; i++)
    {
        string currentName = nameQueue.Dequeue();
        nameQueue.Enqueue(currentName);
    }

    Console.WriteLine($"Removed {nameQueue.Dequeue()}");
}

Console.WriteLine($"Last is {nameQueue.Peek()}");
