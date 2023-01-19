double[] nums = Console.ReadLine()
    .Split(", ")
    .Select(double.Parse)
    .Select(x => x * 1.2)
    .ToArray();

foreach (var num in nums)
{
    Console.WriteLine($"{num:F2}");
}