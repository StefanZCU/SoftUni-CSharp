int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();

char[,] matrix = new char[matrixSize[0], matrixSize[1]];

string snake = Console.ReadLine();

Queue<char> snakeChars = new Queue<char>(snake);

for (int i = 0; i < matrix.GetLength(0); i++)
{
    if (i % 2 == 0)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            var currentSymbol = snakeChars.Dequeue();
            matrix[i, j] = currentSymbol;
            snakeChars.Enqueue(currentSymbol);
        }
    }
    else
    {
        for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
        {
            var currentSymbol = snakeChars.Dequeue();
            matrix[i, j] = currentSymbol;
            snakeChars.Enqueue(currentSymbol);
        }
    }

}

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        Console.Write($"{matrix[i, j]}");
    }

    Console.WriteLine();
}