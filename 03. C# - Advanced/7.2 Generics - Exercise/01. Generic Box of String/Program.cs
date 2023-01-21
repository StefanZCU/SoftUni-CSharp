using System.Linq.Expressions;

namespace GenericBoxOfString
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numBoxes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numBoxes; i++)
            {
                string line = Console.ReadLine();

                Box<string> box = new Box<string>(line);

                Console.WriteLine(box);
            }
        }
    }
}