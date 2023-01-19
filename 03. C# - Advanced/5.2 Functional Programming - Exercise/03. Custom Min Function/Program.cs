int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

int smallest = FindSmallestNumber(numbers, (arr) =>
{
    int min = int.MaxValue;

    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] < min)
        {
            min = arr[i];
        }
    }
    return min;
});

Console.WriteLine(smallest);

int FindSmallestNumber(int[] numbers, Func<int[], int> func)
{
    return func(numbers);
}