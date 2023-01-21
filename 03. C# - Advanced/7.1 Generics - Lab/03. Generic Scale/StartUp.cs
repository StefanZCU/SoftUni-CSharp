namespace GenericScale
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var areEqual = new EqualityScale<string>("Pesho", "Pesho");
            Console.WriteLine(areEqual.AreEqual());
        }
    }
}