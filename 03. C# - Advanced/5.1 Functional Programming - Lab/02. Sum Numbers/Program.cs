int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
Console.WriteLine(numbers.Length);
Console.WriteLine(numbers.Sum());
