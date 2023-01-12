int matrixSize = int.Parse(Console.ReadLine());

char[,] matrix = new char[matrixSize, matrixSize];

for (int i = 0; i < matrixSize; i++)
{
    string symbols = Console.ReadLine();

    for (int j = 0; j < matrixSize; j++)
    {
        matrix[i, j] = symbols[j];
    }
}

char symbolToLookFor = char.Parse(Console.ReadLine());

for (int i = 0; i < matrixSize; i++)
{
    for (int j = 0; j < matrixSize; j++)
    {
        if (matrix[i, j] == symbolToLookFor)
        {
            Console.WriteLine($"({i}, {j})");
            return;
        }
    }
}

Console.WriteLine($"{symbolToLookFor} does not occur in the matrix");