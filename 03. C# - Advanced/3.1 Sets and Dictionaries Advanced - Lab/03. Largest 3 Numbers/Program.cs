int[] sortedArray = Console.ReadLine().Split().Select(int.Parse).OrderByDescending(x => x).ToArray();

if (sortedArray.Length >= 3)
{
    for (int i = 0; i < 3; i++)
    {
        Console.Write($"{sortedArray[i]} ");
    }
}
else
{
    Console.WriteLine(string.Join(" ", sortedArray));
}