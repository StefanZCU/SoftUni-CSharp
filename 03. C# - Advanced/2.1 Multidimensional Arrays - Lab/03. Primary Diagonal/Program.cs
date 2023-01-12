int matrixSize = int.Parse(Console.ReadLine());

int[,] matrix = new int[matrixSize, matrixSize];
int sum = 0;

for (int i = 0; i < matrixSize; i++)
{
    int[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

    for (int j = 0; j < matrixSize; j++)
    {
        matrix[i, j] = nums[j];

        if (i == j)
        {
            sum += nums[j];
        }
    }
}

Console.WriteLine(sum);
