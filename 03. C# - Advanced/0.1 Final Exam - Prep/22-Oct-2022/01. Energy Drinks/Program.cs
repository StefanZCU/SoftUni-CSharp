Stack<int> milligramsCaffeine = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse).ToArray());

Queue<int> energyDrinks = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse).ToArray());

int caffeineTaken = 0;

while (true)
{
    if (milligramsCaffeine.Peek() * energyDrinks.Peek() <= 300 - caffeineTaken)
    {
        caffeineTaken += milligramsCaffeine.Pop() * energyDrinks.Dequeue();
    }
    else
    {
        if (caffeineTaken - 30 <= 0)
        {
            caffeineTaken = 0;
        }
        else
        {
            caffeineTaken -= 30;
        }

        milligramsCaffeine.Pop();
        energyDrinks.Enqueue(energyDrinks.Dequeue());
    }

    if (milligramsCaffeine.Count == 0 && energyDrinks.Count != 0)
    {
        Console.WriteLine($"Drinks left: {string.Join(", ", energyDrinks)}");
        break;
    }

    if (energyDrinks.Count == 0)
    {
        Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
        break;
    }
}

Console.WriteLine($"Stamat is going to sleep with {caffeineTaken} mg caffeine.");


