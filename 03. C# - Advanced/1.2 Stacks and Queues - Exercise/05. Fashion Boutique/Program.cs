int[] clothesInBoxes = Console.ReadLine().Split().Select(int.Parse).ToArray();
int rackCapacity = int.Parse(Console.ReadLine());
Stack<int> clotheStack = new Stack<int>(clothesInBoxes);

int clothesRacks = 1;

int currentRack = 0;

while (clotheStack.Count != 0)
{
    if (currentRack + clotheStack.Peek() > rackCapacity)
    {
        clothesRacks++;
        currentRack = 0;
        currentRack += clotheStack.Pop();
    }
    else if (currentRack + clotheStack.Peek() == rackCapacity)
    {
        clothesRacks++;
        currentRack = 0;
        clotheStack.Pop();
    }
    else
    {
        currentRack += clotheStack.Pop();
    }
}

if (currentRack == 0)
{
    clothesRacks--;
}

Console.WriteLine(clothesRacks);