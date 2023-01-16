int numLines = int.Parse(Console.ReadLine());

HashSet<string> uniqueChemicals = new HashSet<string>();

for (int i = 0; i < numLines; i++)
{
    string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

    for (int j = 0; j < input.Length; j++)
    {
        uniqueChemicals.Add(input[j]);
    }
}

foreach (var uniqueChemical in uniqueChemicals.OrderBy(x => x))
{
    Console.Write($"{uniqueChemical} ");
}