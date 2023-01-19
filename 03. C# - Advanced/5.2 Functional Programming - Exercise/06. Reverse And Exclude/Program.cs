List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

int numberToDivideBy = int.Parse(Console.ReadLine());

numbers.Reverse();
numbers.RemoveAll(x => x % numberToDivideBy == 0);

Console.WriteLine(string.Join(" ", numbers));
