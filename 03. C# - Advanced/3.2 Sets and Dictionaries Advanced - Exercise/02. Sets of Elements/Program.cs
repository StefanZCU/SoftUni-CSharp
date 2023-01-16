int[] length = Console.ReadLine().Split().Select(int.Parse).ToArray();

Queue<int> firstSetOfNums = new Queue<int>();
HashSet<int> secondSet = new HashSet<int>();

for (int i = 0; i < length[0]; i++)
{
    int num = int.Parse(Console.ReadLine());

    firstSetOfNums.Enqueue(num);
}

for (int i = 0; i < length[1]; i++)
{
    int num = int.Parse(Console.ReadLine());
    secondSet.Add(num);
}

List<int> printedNums = new List<int>();

for (int i = 0; i < length[0]; i++)
{
    int currentNum = firstSetOfNums.Dequeue();

    if (secondSet.Contains(currentNum) && !printedNums.Contains(currentNum))
    {
        printedNums.Add(currentNum);
        Console.Write($"{currentNum} ");
    }
}