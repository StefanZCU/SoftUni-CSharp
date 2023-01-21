namespace GenericCountMethodDoubles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numBoxes = int.Parse(Console.ReadLine());
            List<double> elements = new List<double>();

            for (int i = 0; i < numBoxes; i++)
            {
                double line = double.Parse(Console.ReadLine());

                elements.Add(line);
            }

            double elementForComparison = double.Parse(Console.ReadLine());

            Box box = new Box();
            
            Console.WriteLine(box.ComparisonChecker(elementForComparison, elements));

        }
    }
}