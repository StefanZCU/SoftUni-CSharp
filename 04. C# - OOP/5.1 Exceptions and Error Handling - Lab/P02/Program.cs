namespace P02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];
            int index = 0;
            while (index < 10)
            {
                try
                {
                    if (index == 0)
                    {
                        array[index] = ReadNumber(1, 100);
                    }
                    else
                    {
                        array[index] = ReadNumber(array.Max(), 100);
                    }

                    index++;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(string.Join(", ", array));
        }

        static int ReadNumber(int start, int end)
        {
            int num;
            try
            {
                num = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                throw new FormatException("Invalid Number!");
            }

            if (num <= start || num >= end)
            {
                throw new ArgumentException($"Your number is not in range {start} - {end}!");
            }

            return num;
        }
    }
}