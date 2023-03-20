using System.Drawing;

namespace P01
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var length = double.Parse(Console.ReadLine());
                var width = double.Parse(Console.ReadLine());
                var height = double.Parse(Console.ReadLine());

                Box box = new Box(length, width, height);
                Console.WriteLine(box);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}