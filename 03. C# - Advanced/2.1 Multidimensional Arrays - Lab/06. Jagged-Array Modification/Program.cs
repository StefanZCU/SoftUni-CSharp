int rowSize = int.Parse(Console.ReadLine());
int[][] jaggedMatrix = new int[rowSize][];

for (int i = 0; i < jaggedMatrix.GetLength(0); i++)
{
    int[] jaggedCol = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    jaggedMatrix[i] = new int[jaggedCol.Length];

    for (int j = 0; j < jaggedCol.Length; j++)
    {
        jaggedMatrix[i][j] = jaggedCol[j];
    }
}

string command;
while ((command = Console.ReadLine()) != "END")
{
    string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string cmdArg = input[0];
    int row = int.Parse(input[1]);
    int col = int.Parse(input[2]);
    int value = int.Parse(input[3]);

    if (CheckCoords(row, col, jaggedMatrix))
    {
        if (cmdArg == "Add")
        {
            jaggedMatrix[row][col] += value;
        }
        else if (cmdArg == "Subtract")
        {
            jaggedMatrix[row][col] -= value;
        }
    }
    else
    {
        Console.WriteLine("Invalid coordinates");
    }
}

for (int i = 0; i < jaggedMatrix.GetLength(0); i++)
{
    for (int j = 0; j < jaggedMatrix[i].Length; j++)
    {
        Console.Write(jaggedMatrix[i][j] + " ");
    }

    Console.WriteLine();
}

static bool CheckCoords(int row, int col, int[][] jaggedMatrix)
{
    if (row >= 0 && row < jaggedMatrix.GetLength(0) && col >= 0 && col < jaggedMatrix[1].Length)
    {
        return true;
    }

    return false;
}

