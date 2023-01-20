namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            DateModifier dateModifier = new DateModifier();

            Console.WriteLine(dateModifier.CalculateDifference(firstDate, secondDate));
        }
    }
}