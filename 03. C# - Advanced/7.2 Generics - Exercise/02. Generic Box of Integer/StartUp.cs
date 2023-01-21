namespace GenericBoxOfInteger
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numBoxes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numBoxes; i++)
            {
                int line = int.Parse(Console.ReadLine());

                Box<int> box = new Box<int>(line);

                Console.WriteLine(box);
            }
        }
    }
}