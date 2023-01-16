Dictionary<string, Dictionary<string, int>> clothesOccurrencesByColor =
    new Dictionary<string, Dictionary<string, int>>();

int numLines = int.Parse(Console.ReadLine());

for (int i = 0; i < numLines; i++)
{
    string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

    string color = input[0];
    string[] clothes = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

    if (!clothesOccurrencesByColor.ContainsKey(color))
    {
        clothesOccurrencesByColor.Add(color, new Dictionary<string, int>());
    }

    for (int j = 0; j < clothes.Length; j++)
    {
        if (!clothesOccurrencesByColor[color].ContainsKey(clothes[j]))
        {
            clothesOccurrencesByColor[color].Add(clothes[j], 0);
        }

        clothesOccurrencesByColor[color][clothes[j]]++;
    }
}

string[] clotheToFind = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
string colorToFind = clotheToFind[0];
string clothe = clotheToFind[1];

foreach (var color in clothesOccurrencesByColor)
{
    Console.WriteLine($"{color.Key} clothes:");

    foreach (var clothes in color.Value)
    {
        if (color.Key == colorToFind && clothes.Key == clothe)
        {
            Console.WriteLine($"* {clothes.Key} - {clothes.Value} (found!)");
        }
        else
        {
            Console.WriteLine($"* {clothes.Key} - {clothes.Value}");
        }
    }
}