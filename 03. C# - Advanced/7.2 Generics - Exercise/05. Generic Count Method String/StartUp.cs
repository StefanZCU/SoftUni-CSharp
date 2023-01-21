namespace GenericCountMethodString
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numBoxes = int.Parse(Console.ReadLine());
            List<string> elements = new List<string>();

            for (int i = 0; i < numBoxes; i++)
            {
                string line = Console.ReadLine();

                elements.Add(line);
            }

            string elementForComparison = Console.ReadLine();

            Box box = new Box();

            Console.WriteLine(box.ComparisonChecker(elementForComparison, elements));

        }
    }
}