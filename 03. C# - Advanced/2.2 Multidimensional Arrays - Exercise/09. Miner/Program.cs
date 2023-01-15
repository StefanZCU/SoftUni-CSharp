int matrixSize = int.Parse(Console.ReadLine());
string[] moves = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

int coals = 0;
int minerRow = 0;
int minerCol = 0;
string[,] field = new string[matrixSize, matrixSize];

for (int i = 0; i < matrixSize; i++)
{
    string[] row = Console.ReadLine().Split();

    for (int j = 0; j < matrixSize; j++)
    {
        field[i, j] = row[j];

        if (row[j] == "c")
        {
            coals++;
        }

        if (row[j] == "s")
        {
            minerRow = i;
            minerCol = j;
        }
    }
}

for (int i = 0; i < moves.Length; i++)
{
    if (moves[i] == "up")
    {
        if (minerRow > 0)
        {
            minerRow--;
        }
    }
    else if (moves[i] == "down")
    {
        if (minerRow < matrixSize - 1)
        {
            minerRow++;
        }
    }
    else if (moves[i] == "left")
    {
        if (minerCol > 0)
        {
            minerCol--;
        }
    }
    else if (moves[i] == "right")
    {
        if (minerCol < matrixSize - 1)
        {
            minerCol++;
        }
    }

    if (field[minerRow, minerCol] == "c")
    {
        coals--;
        field[minerRow, minerCol] = "*";
        if (coals == 0)
        {
            Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
            return;
        }
    }
    else if (field[minerRow, minerCol] == "e")
    {
        Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
        return;
    }
}

Console.WriteLine($"{coals} coals left. ({minerRow}, {minerCol})");
