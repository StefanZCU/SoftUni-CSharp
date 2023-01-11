Queue<string> names = new Queue<string>();

string command;
while ((command = Console.ReadLine()) != "End")
{
    if (command != "Paid")
    {
        names.Enqueue(command);
    }
    else
    {
        while (names.Count != 0)
        {
            Console.WriteLine(names.Dequeue());
        }
    }
}

Console.WriteLine($"{names.Count} people remaining.");
