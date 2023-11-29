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

            //Problem 09.
            //string inputJson = File.ReadAllText(@"../../../Datasets/suppliers.json");
            //Console.WriteLine(ImportSuppliers(context, inputJson));

            //Problem 10.
            string inputJson = File.ReadAllText(@"../../../Datasets/parts.json");
            Console.WriteLine(ImportParts(context, inputJson));
        }

        //Problem 09.
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            List<Supplier> suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson)!;
            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        //Problem 10.
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var supplierListIds = context.Suppliers
                .Select(s => s.Id)
                .ToList();

            var parts = JsonConvert
                .DeserializeObject<List<Part>>(inputJson)!
                .Where(p => supplierListIds.Contains(p.SupplierId))
                .ToList();

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }
    }
}