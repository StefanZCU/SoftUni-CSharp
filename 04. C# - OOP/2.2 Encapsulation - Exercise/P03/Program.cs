namespace P03
{
    using System.Text;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] persons = Console.ReadLine().Split(';');
            string[] products = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            List<Person> personList = new List<Person>();
            List<Product> productsList = new List<Product>();

            foreach (var person in persons)
            {
                string[] personInfo = person.Split('=');

                try
                {
                    Person newPerson = new Person(personInfo[0], int.Parse(personInfo[1]));
                    personList.Add(newPerson);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
            }

            foreach (var product in products)
            {
                string[] productInfo = product.Split('=');

                try
                {
                    Product newProduct = new Product(productInfo[0], int.Parse(productInfo[1]));
                    productsList.Add(newProduct);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] input = command.Split();

                string personName = input[0];
                string productName = input[1];

                Console.WriteLine(personList.First(x => x.Name == personName).AddProduct(productName, productsList));
            }

            foreach (var person in personList)
            {
                if (person.Products.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                    continue;
                }

                Console.Write($"{person.Name} - ");
                StringBuilder sb = new StringBuilder();
                foreach (var personProduct in person.Products)
                {
                    sb.Append($"{personProduct.Name}, ");
                }

                sb.Remove(sb.Length - 2, 1);

                Console.Write(sb.ToString());

                Console.WriteLine();
            }
        }
    }
}