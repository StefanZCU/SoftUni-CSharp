int numRows = int.Parse(Console.ReadLine());
int[][] jaggedArray = new int[numRows][];

for (int i = 0; i < numRows; i++)
{
    int[] cols = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

    jaggedArray[i] = new int[cols.Length];

    for (int j = 0; j < cols.Length; j++)
    {
        jaggedArray[i][j] = cols[j];
    }
}

AnlysisOfMatrix(numRows, jaggedArray);

string command;
while ((command = Console.ReadLine()) != "End")
{
    string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (IndexChecker(input, jaggedArray))
    {
        string cmdArg = input[0];
        int row = int.Parse(input[1]);
        int col = int.Parse(input[2]);
        int value = int.Parse(input[3]);

        if (cmdArg == "Add")
        {
            jaggedArray[row][col] += value;
        }
        else if (cmdArg == "Subtract")
        {
            jaggedArray[row][col] -= value;
        }
    }
}

for (int i = 0; i < jaggedArray.Length; i++)
{
    Console.WriteLine(string.Join(" ", jaggedArray[i]));
}




int[][] AnlysisOfMatrix(int numRows1, int[][] ints)
{
    for (int i = 0; i < numRows1 - 1; i++)
    {
        if (ints[i].Length == ints[i + 1].Length)
        {
            for (int j = 0; j < ints[i].Length; j++)
            {
                ints[i][j] *= 2;
            }

            for (int j = 0; j < ints[i + 1].Length; j++)
            {
                ints[i + 1][j] *= 2;
            }
        }
        else
        {
            for (int j = 0; j < ints[i].Length; j++)
            {
                ints[i][j] /= 2;
            }

            for (int j = 0; j < ints[i + 1].Length; j++)
            {
                ints[i + 1][j] /= 2;
            }
        }
    }

    return ints;
}

bool IndexChecker(string[] input, int[][] jaggedArray)
{
    int row = int.Parse(input[1]);
    int col = int.Parse(input[2]);

    if (row >= 0 && row < jaggedArray.Length &&
        col >= 0 && col < jaggedArray[row].Length)
    {
        return true;
    }

    return false;

}
