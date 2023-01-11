int foodQuantity = int.Parse(Console.ReadLine());

int[] orderSizes = Console.ReadLine().Split().Select(int.Parse).ToArray();

Queue<int> orders = new Queue<int>(orderSizes);
Console.WriteLine(orders.Max());

for (int i = 0; i < orderSizes.Length; i++)
{
    if (foodQuantity - orders.Peek() >= 0)
    {
        foodQuantity -= orders.Dequeue();
    }
    else
    {
        Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
        break;
    }

    if (orders.Count == 0)
    {
        Console.WriteLine("Orders complete");
        break;
    }
}