using Newtonsoft.Json;
using ProductShop.DTOs.Import;

namespace ProductShop
{
    using AutoMapper;
    using ProductShop.Data;
    using ProductShop.Models;

    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            //Problem 01.
            //string inputJson = File.ReadAllText(@"../../../Datasets/users.json");
            //Console.WriteLine(ImportUsers(context, inputJson));

            //Problem 02.
            //string inputJson = File.ReadAllText(@"../../../Datasets/products.json");
            //Console.WriteLine(ImportProducts(context, inputJson));

            //Problem 03.
            //string inputJson = File.ReadAllText(@"../../../Datasets/categories.json");
            //Console.WriteLine(ImportCategories(context, inputJson));

            //Problem 04.
            string inputJson = File.ReadAllText(@"../../../Datasets/categories-products.json");
            Console.WriteLine(ImportCategoryProducts(context, inputJson));
        }

        //Problem 01.
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportUserDto[] userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);

            ICollection<User> validUsers = new HashSet<User>();
            foreach (ImportUserDto userDto in userDtos)
            {
                User user = mapper.Map<User>(userDto);

                validUsers.Add(user);
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

        //Problem 02.
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportProductDto[] productDtos = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);
            Product[] products = mapper.Map<Product[]>(productDtos);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";

        }

        //Problem 03.
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportCategoryDto[] categoryDtos = JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson);

            ICollection<Category> validCategories = new HashSet<Category>();
            foreach (var categoryDto in categoryDtos)
            {
                if (string.IsNullOrWhiteSpace(categoryDto.Name))
                {
                    continue;
                }

                Category category = mapper.Map<Category>(categoryDto);
                validCategories.Add(category);
            }

            context.Categories.AddRange(validCategories);
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";

        }

        //Problem 04.
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportCategoryProductDto[] categoryProductDtos =
                JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson);

            ICollection<CategoryProduct> validEntries = new HashSet<CategoryProduct>();
            foreach (ImportCategoryProductDto cpDto in categoryProductDtos)
            {
                //if (!context.Categories.Any(c => c.Id == cpDto.CategoryId) ||
                //    !context.Products.Any(p => p.Id == cpDto.ProductId))
                //{
                //    continue;
                //}

                CategoryProduct categoryProduct =
                    mapper.Map<CategoryProduct>(cpDto);
                validEntries.Add(categoryProduct);
            }

            context.CategoriesProducts.AddRange(validEntries);
            context.SaveChanges();

            return $"Successfully imported {validEntries.Count}";

        }

        private static IMapper CreateMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));
        }
    }
}