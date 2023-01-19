string[] sentence = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

Func<string, bool> CheckUpper = x => char.IsUpper(x[0]);

for (int i = 0; i < sentence.Length; i++)
{
    if (CheckUpper(sentence[i]))
    {
        Console.WriteLine(sentence[i]);
    }
}

