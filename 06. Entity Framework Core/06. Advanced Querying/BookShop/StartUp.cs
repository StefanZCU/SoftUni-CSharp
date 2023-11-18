using System.Diagnostics;
using System.Text;
using BookShop.Models.Enums;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //Problem 02.
            //Console.WriteLine(GetBooksByAgeRestriction(db, "miNor"));

            //Problem 03.
            //Console.WriteLine(GetGoldenBooks(db));

            //Problem 04.
            //Console.WriteLine(GetBooksByPrice(db));
        }

        //Problem 02.
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var sb = new StringBuilder();

            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var allBookTitles = context.Books
                .OrderBy(x => x.Title)
                .Where(x => x.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .ToList();

            foreach (var book in allBookTitles)
            {
                sb.AppendLine(book.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 03.
        public static string GetGoldenBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var allGoldenBooksWithOver5000Copies = context.Books
                .Where(x => x.EditionType == EditionType.Gold
                            && x.Copies < 5000)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList();

            foreach (var book in allGoldenBooksWithOver5000Copies)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 04.
        public static string GetBooksByPrice(BookShopContext context)
        {
            var sb = new StringBuilder();

            var allBooksWithPriceHigherThan40 = context.Books
                .Where(x => x.Price > 40)
                .Select(b => new
                {
                    BookTitle = b.Title,
                    BookPrice = b.Price
                })
                .OrderByDescending(x => x.BookPrice)
                .ToList();

            foreach (var book in allBooksWithPriceHigherThan40)
            {
                sb.AppendLine($"{book.BookTitle} - ${book.BookPrice:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}


