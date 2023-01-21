namespace GenericSwapMethodInteger
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numBoxes = int.Parse(Console.ReadLine());

            List<int> boxes = new List<int>();

            for (int i = 0; i < numBoxes; i++)
            {
                int element = int.Parse(Console.ReadLine());
                boxes.Add(element);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int indexOne = indexes[0];
            int indexTwo = indexes[1];

            Box boxObject = new Box();

            boxObject.SwapMethod(indexOne, indexTwo, boxes);

            foreach (var box in boxes)
            {
                Console.WriteLine($"{box.GetType()}: {box}");
            }
        }
    }
}