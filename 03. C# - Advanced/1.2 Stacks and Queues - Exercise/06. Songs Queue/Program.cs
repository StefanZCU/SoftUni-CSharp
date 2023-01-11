string[] songs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

Queue<string> songQueue = new Queue<string>(songs);

while (songQueue.Count != 0)
{
    string command = Console.ReadLine();

    if (command.Contains("Add"))
    {
        string songName = command.Substring(3, command.Length - 3).TrimStart();

        if (!songQueue.Contains(songName))
        {
            songQueue.Enqueue(songName);
        }
        else
        {
            Console.WriteLine($"{songName} is already contained!");
        }
    }
    else if (command == "Play")
    {
        songQueue.Dequeue();
    }
    else if (command == "Show")
    {
        Console.WriteLine(string.Join(", ", songQueue));
    }
}

Console.WriteLine("No more songs!");
