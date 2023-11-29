using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            //Problem 01.
            //string inputJson = File.ReadAllText(@"../../../Datasets/suppliers.json");
            //Console.WriteLine(ImportSuppliers(context, inputJson));
        }

        //Problem 01.
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            List<Supplier> suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson)!;
            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }
    }
}