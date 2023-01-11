int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

Queue<int> evenNums = new Queue<int>();

foreach (var num in nums)
{
    if (num % 2 == 0)
    {
        evenNums.Enqueue(num);
    }
}

Console.WriteLine(string.Join(", ", evenNums));