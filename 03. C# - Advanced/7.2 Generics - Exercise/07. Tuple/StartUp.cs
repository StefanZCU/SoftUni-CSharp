namespace Tuple
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var personInfo = Console.ReadLine().Split();

            string fullName = $"{personInfo[0]} {personInfo[1]}";
            string address = personInfo[2];

            var personData = new Tuple<string, string>(fullName, address);

            Console.WriteLine(personData);

            var personBeer = Console.ReadLine().Split();

            string name = personBeer[0];
            int beerQnt = int.Parse(personBeer[1]);

            var beerData = new Tuple<string, int>(name, beerQnt);

            Console.WriteLine(beerData);

            var numbersLine = Console.ReadLine().Split();

            int intNum = int.Parse(numbersLine[0]);
            double doubleNum = double.Parse(numbersLine[1]);

            var numberData = new Tuple<int, double>(intNum, doubleNum);
            Console.WriteLine(numberData);
        }
    }
}