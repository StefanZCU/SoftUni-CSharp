double[] digits = Console.ReadLine().Split().Select(double.Parse).ToArray();

Dictionary<double, int> occurences = new Dictionary<double, int>();

foreach (var digit in digits)
{
    if (!occurences.ContainsKey(digit))
    {
        occurences.Add(digit, 0);
    }

    occurences[digit]++;
}

foreach (var occurence in occurences)
{
    Console.WriteLine($"{occurence.Key} - {occurence.Value} times");
}