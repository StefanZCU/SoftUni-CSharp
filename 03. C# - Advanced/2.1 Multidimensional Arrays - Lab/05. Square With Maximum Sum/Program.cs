int[] matrixSize = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

int[,] matrix = new int[matrixSize[0], matrixSize[1]];

for (int i = 0; i < matrix.GetLength(0); i++)
{
    int[] cols = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = cols[j];
    }
}

int topLeftCoordRow = 0;
int topLeftCoordCol = 0;
int sum = int.MinValue;

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (i + 1 < matrix.GetLength(0) && j + 1 < matrix.GetLength(1))
        {
            if (matrix[i, j] + matrix[i + 1, j] + matrix[i, j + 1] + matrix[i + 1, j + 1] > sum)
            {
                sum = matrix[i, j] + matrix[i + 1, j] + matrix[i, j + 1] + matrix[i + 1, j + 1];
                topLeftCoordRow = i;
                topLeftCoordCol = j;
            }
        }
    }
}

Console.WriteLine($"{matrix[topLeftCoordRow, topLeftCoordCol]} {matrix[topLeftCoordRow, topLeftCoordCol + 1]}");
Console.WriteLine($"{matrix[topLeftCoordRow + 1, topLeftCoordCol]} {matrix[topLeftCoordRow + 1, topLeftCoordCol + 1]}");
Console.WriteLine(sum);