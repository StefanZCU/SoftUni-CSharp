using _04.Froggy;

List<int> stones = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

Lake lake = new Lake(stones);

Console.WriteLine(string.Join(", ", lake));
