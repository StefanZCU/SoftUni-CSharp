int[] foodArray = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int[] staminaArray = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

List<int> mountainDifficulties = new List<int> { 80, 90, 100, 60, 70 };

List<string> conqueredMountains = new List<string>();

Stack<int> foodPortions = new Stack<int>(foodArray);
Queue<int> staminaQnt = new Queue<int>(staminaArray);

while (mountainDifficulties.Count != 0)
{
    string currMountain = string.Empty;

    switch (mountainDifficulties[0])
    {
        case 60:
            currMountain = "Polezhan";
            break;
        case 70:
            currMountain = "Kamenitza";
            break;
        case 80:
            currMountain = "Vihren";
            break;
        case 90:
            currMountain = "Kutelo";
            break;
        case 100:
            currMountain = "Banski Suhodol";
            break;
    }

    if (foodPortions.Peek() + staminaQnt.Peek() >= mountainDifficulties[0])
    {
        foodPortions.Pop();
        staminaQnt.Dequeue();
        mountainDifficulties.RemoveAt(0);
        conqueredMountains.Add(currMountain);
    }
    else if (foodPortions.Peek() + staminaQnt.Peek() < mountainDifficulties[0])
    {
        foodPortions.Pop();
        staminaQnt.Dequeue();
    }

    if (mountainDifficulties.Count == 0)
    {
        Console.WriteLine($"Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
        Console.WriteLine($"Conquered peaks:\n{string.Join("\n", conqueredMountains)}");
        break;
    }


    if ((foodPortions.Count == 0 && staminaQnt.Count == 0) && mountainDifficulties.Count != 0)
    {
        Console.WriteLine($"Alex failed! He has to organize his journey better next time -> @PIRINWINS");

        if (conqueredMountains.Count != 0)
        {
            Console.WriteLine($"Conquered peeks;\n{string.Join("\n", conqueredMountains)}");
        }

        break;
    }

}