int[] commands = Console.ReadLine().Split().Select(int.Parse).ToArray();

int N = commands[0]; //Number of elements to Push
int S = commands[1]; //Number of elements to Pop
int X = commands[2]; //Number to look for in Stack

Queue<int> numbers = new Queue<int>();

int[] numbersToAdd = Console.ReadLine().Split().Select(int.Parse).ToArray();

for (int i = 0; i < N; i++)
{
    numbers.Enqueue(numbersToAdd[i]);
}

for (int i = 0; i < S; i++)
{
    numbers.Dequeue();
}

if (numbers.Contains(X))
{
    Console.WriteLine("true");
}
else if (numbers.Count == 0)
{
    Console.WriteLine(0);
}
else
{
    Console.WriteLine(numbers.Min());
}


