int[] matrixSize = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

int[,] matrix = new int[matrixSize[0], matrixSize[1]];

for (int i = 0; i < matrixSize[0]; i++)
{
    int[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

    for (int j = 0; j < matrixSize[1]; j++)
    {
        matrix[i, j] = nums[j];
    }
}

for (int i = 0; i < matrixSize[1]; i++)
{
    int sum = 0;

    for (int j = 0; j < matrixSize[0]; j++)
    {
        sum += matrix[j, i];
    }

    Console.WriteLine(sum);
}