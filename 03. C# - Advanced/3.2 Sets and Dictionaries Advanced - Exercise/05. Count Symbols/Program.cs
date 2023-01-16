Dictionary<char, int> letterOccurrences = new Dictionary<char, int>();

string sentence = Console.ReadLine();

foreach (var letter in sentence)
{
    if (!letterOccurrences.ContainsKey(letter))
    {
        letterOccurrences.Add(letter, 0);
    }

    letterOccurrences[letter]++;
}

foreach (var letterOccurrence in letterOccurrences.OrderBy(x => x.Key))
{
    Console.WriteLine($"{letterOccurrence.Key}: {letterOccurrence.Value} time/s");
}
