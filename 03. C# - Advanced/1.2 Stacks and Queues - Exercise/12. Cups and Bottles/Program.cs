int[] cupCapacityArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
int[] bottlesArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

Stack<int> bottles = new Stack<int>(bottlesArray);
Queue<int> cups = new Queue<int>(cupCapacityArray);

int wastedLiters = 0;

while (true)
{
    if (bottles.Count != 0 && cups.Count != 0)
    {
        if (bottles.Peek() - cups.Peek() > 0)
        {
            wastedLiters += bottles.Pop() - cups.Dequeue();
        }
        else if (bottles.Peek() - cups.Peek() == 0)
        {
            bottles.Pop();
            cups.Dequeue();
        }
        else if (bottles.Peek() - cups.Peek() < 0)
        {
            cups.Enqueue(cups.Dequeue() - bottles.Pop());

            for (int i = 1; i < cups.Count; i++)
            {
                cups.Enqueue(cups.Dequeue());
            }
        }

    }
    else if (bottles.Count == 0)
    {
        Console.WriteLine($"Cups: {string.Join(" ", cups)}");
        Console.WriteLine($"Wasted litters of water: {wastedLiters}");
        break;
    }
    else
    {
        Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
        Console.WriteLine($"Wasted litters of water: {wastedLiters}");
        break;
    }
}