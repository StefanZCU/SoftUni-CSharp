namespace P05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] originalArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int exceptionsCaught = 0;
            while (exceptionsCaught != 3)
            {
                string[] cmdArgs = Console.ReadLine().Split();

                string command = cmdArgs[0];

                try
                {
                    if (command == "Replace")
                    {
                        int index = int.Parse(cmdArgs[1]);
                        int element = int.Parse(cmdArgs[2]);

                        originalArray[index] = element;
                    }
                    else if (command == "Print")
                    {
                        int startIndex = int.Parse(cmdArgs[1]);
                        int endIndex = int.Parse(cmdArgs[2]);

                        int[] arrayCopy = new int[(endIndex - startIndex) + 1];
                        Array.Copy(originalArray, startIndex, arrayCopy, 0, (endIndex - startIndex) + 1);

                        Console.WriteLine(string.Join(", ", arrayCopy));
                    }
                    else if (command == "Show")
                    {
                        int index = int.Parse(cmdArgs[1]);

                        Console.WriteLine(originalArray[index]);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptionsCaught++;
                }
                catch (Exception ex) when (ex is IndexOutOfRangeException or ArgumentOutOfRangeException or ArgumentException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptionsCaught++;
                }
            }

            Console.WriteLine(string.Join(", ", originalArray));
        }
    }
}