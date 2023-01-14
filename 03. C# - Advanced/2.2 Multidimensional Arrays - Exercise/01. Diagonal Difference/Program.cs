int matrixSize = int.Parse(Console.ReadLine());

int[,] matrix = new int[matrixSize, matrixSize];

int mainDiagonalSum = 0;
int secondaryDiagonalSum = 0;

for (int row = 0; row < matrix.GetLength(0); row++)
{
    int[] cols = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

    for (int col = 0; col < matrix.GetLength(1); col++)
    {
        matrix[row, col] = cols[col];

        if (row == col)
        {
            mainDiagonalSum += cols[col];
        }

        if (row + col == matrixSize - 1)
        {
            secondaryDiagonalSum += cols[col];
        }
    }
}

Console.WriteLine(Math.Abs(mainDiagonalSum - secondaryDiagonalSum));


