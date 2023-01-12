int[] rowAndColsSize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

int[,] matrix = new int[rowAndColsSize[0], rowAndColsSize[1]];

for (int i = 0; i < rowAndColsSize[0]; i++)
{
    int[] cols = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

    for (int j = 0; j < rowAndColsSize[1]; j++)
    {
        matrix[i, j] = cols[j];
    }
}

int highestValue = int.MinValue;
int[] firstPair = new int[2];
int[] secondPair = new int[2];

for (int i = 0; i < rowAndColsSize[0] - 1; i++)
{
    for (int j = 0; j < rowAndColsSize[1] - 1; j++)
    {
        if (matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1] > highestValue)
        {
            highestValue = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];
            firstPair[0] = matrix[i, j];
            firstPair[1] = matrix[i, j + 1];
            secondPair[0] = matrix[i + 1, j];
            secondPair[1] = matrix[i + 1, j + 1];
        }
    }
}

Console.WriteLine(string.Join(" ", firstPair));
Console.WriteLine(string.Join(" ", secondPair));
Console.WriteLine(highestValue);