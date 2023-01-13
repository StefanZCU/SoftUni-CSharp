int[] cupCapacityArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
int[] bottlesArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

Stack<int> bottles = new Stack<int>(bottlesArray);
Queue<int> cups = new Queue<int>(cupCapacityArray);

int wastedLiters = 0;

while (bottles.Count != 0 && cups.Count != 0)
{
    if (bottles.Peek() >= cups.Peek())
    {
        wastedLiters += bottles.Pop() - cups.Dequeue();
    }
    else
    {
        int remainingVolume = cups.Dequeue() - bottles.Pop();
        while (remainingVolume > 0 && bottles.Count > 0)
        {
            if (bottles.Peek() >= remainingVolume)
            {
                wastedLiters += bottles.Pop() - remainingVolume;
                remainingVolume = 0;
            }
            else
            {
                remainingVolume -= bottles.Pop();
            }
        }
    }
}

if (bottles.Count == 0)
{
    Console.WriteLine($"Cups: {string.Join(" ", cups)}");
    Console.WriteLine($"Wasted litters of water: {wastedLiters}");
}
else
{
    Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
    Console.WriteLine($"Wasted litters of water: {wastedLiters}");
}