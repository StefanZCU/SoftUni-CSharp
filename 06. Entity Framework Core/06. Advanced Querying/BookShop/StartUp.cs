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
            Console.WriteLine(GetBooksByAgeRestriction(db, "miNor"));
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
    }
}


