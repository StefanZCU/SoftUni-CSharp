using System.Reflection.Metadata.Ecma335;

namespace Threeuple
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var personInfo = Console.ReadLine().Split();

            string fullName = $"{personInfo[0]} {personInfo[1]}";
            string address = personInfo[2];
            string town = personInfo[3];

            var personData = new Threeuple<string, string, string>(fullName, address, town);
            Console.WriteLine(personData);

            var personBeer = Console.ReadLine().Split();

            string name = personBeer[0];
            int beerQnt = int.Parse(personBeer[1]);
            bool drunkOrNot = personBeer[2] == "drunk";

            var beerData = new Threeuple<string, int, bool>(name, beerQnt, drunkOrNot);

            Console.WriteLine(beerData);

            var bankInfo = Console.ReadLine().Split();

            string firstName = bankInfo[0];
            double bankBalance = double.Parse(bankInfo[1]);
            string bankName = bankInfo[2];

            var bankData = new Threeuple<string, double, string>(firstName, bankBalance, bankName);
            Console.WriteLine(bankData);
        }
    }
}