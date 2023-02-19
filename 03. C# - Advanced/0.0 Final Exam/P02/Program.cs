namespace P02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];

            char[][] matrix = new char[rows][];

            int[] position = new int[2];
            int totalPlayers = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                matrix[i] = new char[cols];

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (line[j] == 'B')
                    {
                        position[0] = i;
                        position[1] = j;
                        matrix[i][j] = '-';
                        continue;
                    }
                    
                    if (line[j] == 'P')
                    {
                        totalPlayers++;
                    }

                    matrix[i][j] = line[j];
                }
            }

            int movesMade = 0;
            int touches = 0;

            string command;
            while ((command = Console.ReadLine()) != "Finish")
            {
                int row = position[0];
                int col = position[1];

                switch (command)
                {
                    case "up":
                        if (IndexChecker(--row, col, matrix) && ObstacleChecker(row, col, matrix))
                        {
                            position[0]--;
                            movesMade++;
                        }
                        break;
                    case "down":
                        if (IndexChecker(++row, col, matrix) && ObstacleChecker(row, col, matrix))
                        {
                            position[0]++;
                            movesMade++;
                        }
                        break;
                    case "left":
                        if (IndexChecker(row, --col, matrix) && ObstacleChecker(row, col, matrix))
                        {
                            position[1]--;
                            movesMade++;
                        }
                        break;
                    case "right":
                        if (IndexChecker(row, ++col, matrix) && ObstacleChecker(row, col, matrix))
                        {
                            position[1]++;
                            movesMade++;
                        }
                        break;
                }

                row = position[0];
                col = position[1];

                if (matrix[row][col] != 'P') continue;
                totalPlayers--;
                touches++;
                matrix[row][col] = '-';

                if (totalPlayers == 0)
                {
                    break;
                }
            }

            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {touches} Moves made: {movesMade}");
        }

        static bool IndexChecker(int row, int col, char[][] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix[row].Length;
        }

        static bool ObstacleChecker(int row, int col, char[][] matrix)
        {
            return matrix[row][col] != 'O';
        }
    }
}