using System.Numerics;

int numPumps = int.Parse(Console.ReadLine());

Queue<string> petrolPumps = new Queue<string>();

for (int i = 0; i < numPumps; i++)
{
    petrolPumps.Enqueue(Console.ReadLine());
}

for (int i = 0; i < numPumps; i++)
{
    BigInteger currentPetrolAmt = 0;
    bool flag = true;

    for (int j = 0; j < numPumps; j++)
    {
        BigInteger[] currPump = petrolPumps.Dequeue().Split().Select(BigInteger.Parse).ToArray();
        petrolPumps.Enqueue(string.Join(" ", currPump));

        currentPetrolAmt += currPump[0];
        currentPetrolAmt -= currPump[1];

        if (currentPetrolAmt < 0)
        {
            flag = false;
        }
    }

    if (flag)
    {
        Console.WriteLine(i);
        break;
    }

    string temp = petrolPumps.Dequeue();
    petrolPumps.Enqueue(temp);
}