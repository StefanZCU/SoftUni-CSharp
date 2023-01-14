int[] matrixSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

int[,] matrix = new int[matrixSize[0], matrixSize[1]];

for (int i = 0; i < matrix.GetLength(0); i++)
{
    int[] cols = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = cols[j];
    }
}

int topLeftCoordRow = 0;
int topLeftCoordCol = 0;
int bottomRightRow = 0;
int bottomRightCol = 0;
int sum = int.MinValue;

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (i + 2 < matrix.GetLength(0) && j + 2 < matrix.GetLength(1))
        {
            if (matrix[i, j]
                + matrix[i, j + 1]
                + matrix[i, j + 2]
                + matrix[i + 1, j]
                + matrix[i + 1, j + 1]
                + matrix[i + 1, j + 2]
                + matrix[i + 2, j]
                + matrix[i + 2, j + 1]
                + matrix[i + 2, j + 2] > sum)
            {
                sum = matrix[i, j]
                      + matrix[i, j + 1]
                      + matrix[i, j + 2]
                      + matrix[i + 1, j]
                      + matrix[i + 1, j + 1]
                      + matrix[i + 1, j + 2]
                      + matrix[i + 2, j]
                      + matrix[i + 2, j + 1]
                      + matrix[i + 2, j + 2];

                topLeftCoordRow = i;
                topLeftCoordCol = j;
                bottomRightRow = i + 2;
                bottomRightCol = j + 2;
            }
        }
    }
}

Console.WriteLine($"Sum = {sum}");

for (int i = topLeftCoordRow; i <= bottomRightRow; i++)
{
    for (int j = topLeftCoordCol; j <= bottomRightCol; j++)
    {
        Console.Write(matrix[i, j] + " ");
    }

    Console.WriteLine();
}