using System.Globalization;
using System.Net.Mime;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
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
            //string inputJson = File.ReadAllText(@"../../../Datasets/parts.json");
            //Console.WriteLine(ImportParts(context, inputJson));

            //Problem 11.
            //string inputJson = File.ReadAllText(@"../../../Datasets/cars.json");
            //Console.WriteLine(ImportCars(context, inputJson));

            //Problem 12.
            //string inputJson = File.ReadAllText(@"../../../Datasets/customers.json");
            //Console.WriteLine(ImportCustomers(context, inputJson));

            //Problem 13.
            //string inputJson = File.ReadAllText(@"../../../Datasets/sales.json");
            //Console.WriteLine(ImportSales(context, inputJson));

            //Problem 14.
            //Console.WriteLine(GetOrderedCustomers(context));

            //Problem 15.
            //Console.WriteLine(GetCarsFromMakeToyota(context));

            //Problem 16.
            //Console.WriteLine(GetLocalSuppliers(context));

            //Problem 17.
            //Console.WriteLine(GetCarsWithTheirListOfParts(context));

            //Problem 18.
            //Console.WriteLine(GetTotalSalesByCustomer(context));

            //Problem 19.
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
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

        //Problem 11.
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            List<CarDto> carsDtos = JsonConvert.DeserializeObject<List<CarDto>>(inputJson);

            List<Car> cars = new List<Car>();
            List<PartCar> parts = new List<PartCar>();

            foreach (var carDto in carsDtos)
            {
                Car car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TraveledDistance = carDto.TraveledDistance
                };

                cars.Add(car);

                parts.AddRange(carDto.PartIds.Distinct().Select(carPart => new PartCar() { Car = car, PartId = carPart }));
            }

            context.AddRange(parts);
            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        //Problem 12.
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson)!;
            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        //Problem 13.
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson)!;

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        //Problem 14.
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    c.IsYoungDriver
                })
                .AsNoTracking()
                .ToList();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        //Problem 15.
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var carsFromToyota = context.Cars
                .Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TraveledDistance)
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TraveledDistance
                })
                .AsNoTracking()
                .ToList();

            return JsonConvert.SerializeObject(carsFromToyota, Formatting.Indented);
        }

        //Problem 16.
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count
                })
                .AsNoTracking()
                .ToList();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        //Problem 17.
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        c.Make,
                        c.Model,
                        c.TraveledDistance
                    },
                    parts = c.PartsCars
                        .Select(p => new
                        {
                            Name = p.Part.Name,
                            Price = p.Part.Price.ToString("0.00")
                        })
                })
                .AsNoTracking()
                .ToList();

            return JsonConvert.SerializeObject(carsWithParts, Formatting.Indented);
        }

        //Problem 18.
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(cus => cus.Sales.Any())
                .Select(cus => new
                {
                    fullName = cus.Name,
                    boughtCars = cus.Sales.Count(),
                    moneyCars = cus.Sales
                        .SelectMany(c => c.Car.PartsCars.Select(p => p.Part.Price))
                })
                .AsNoTracking()
                .ToArray();

            var output = customers
                .Select(o => new
                {
                    o.fullName,
                    o.boughtCars,
                    spentMoney = o.moneyCars.Sum()
                })
                .OrderByDescending(o => o.spentMoney)
                .ThenByDescending(o => o.boughtCars)
                .ToArray();

            return JsonConvert.SerializeObject(output, Formatting.Indented);
        }

        //Problem 19.
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TraveledDistance,
                    },

                    customerName = s.Customer.Name,
                    discount = s.Discount.ToString("0.00"),
                    price = s.Car.PartsCars.Sum(p => p.Part.Price).ToString("0.00"),
                    priceWithDiscount = (s.Car.PartsCars.Sum(p => p.Part.Price) * (1 - s.Discount / 100)).ToString("0.00")
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }
    }
}