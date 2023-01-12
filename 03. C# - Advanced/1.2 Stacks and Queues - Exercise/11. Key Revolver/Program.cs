int bulletPrice = int.Parse(Console.ReadLine());
int gunBarrelSize = int.Parse(Console.ReadLine());
int[] bulletsArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
int[] locksArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
int intelligenceValue = int.Parse(Console.ReadLine());

Queue<int> locks = new Queue<int>(locksArray);
Stack<int> bullets = new Stack<int>(bulletsArray);

int usedBullets = 0;


while (true)
{
    for (int i = 0; i < gunBarrelSize; i++)
    {
        int currentBullet = bullets.Peek();
        int currentSafe = locks.Peek();

        if (currentBullet > currentSafe)
        {
            Console.WriteLine("Ping!");
            usedBullets++;
            bullets.Pop();
        }
        else
        {
            Console.WriteLine("Bang!");
            usedBullets++;
            bullets.Pop();
            locks.Dequeue();
        }

        if (bullets.Count == 0 && locks.Count != 0)
        {
            Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            return;
        }

        if (locks.Count == 0)
        {
            if (usedBullets % gunBarrelSize == 0 && bullets.Count != 0)
            {
                Console.WriteLine("Reloading!");
            }

            Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue - (bulletPrice * usedBullets)}");
            return;
        }
    }

    if (bullets.Count != 0 && usedBullets % gunBarrelSize == 0)
    {
        Console.WriteLine("Reloading!");
    }
}