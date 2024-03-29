﻿using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using BookShop.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace BookShop
{
    using BookShop.Models;
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

            //Problem 05.
            //Console.WriteLine(GetBooksNotReleasedIn(db, 2000));

            //Problem 06.
            //Console.WriteLine(GetBooksByCategory(db, "horror mystery drama"));

            //Problem 07.
            //Console.WriteLine(GetBooksReleasedBefore(db, "12-04-1992"));

            //Problem 08.
            //Console.WriteLine(GetAuthorNamesEndingIn(db, "e"));

            //Problem 09.
            //Console.WriteLine(GetBookTitlesContaining(db, "sK"));

            //Problem 10.
            //Console.WriteLine(GetBooksByAuthor(db, "rYs"));

            //Problem 11.
            //Console.WriteLine(CountBooks(db, 12));

            //Problem 12.
            //Console.WriteLine(CountCopiesByAuthor(db));

            //Problem 13.
            //Console.WriteLine(GetTotalProfitByCategory(db));

            //Problem 14.
            //Console.WriteLine(GetMostRecentBooks(db));

            //Problem 16.
            //Console.WriteLine(RemoveBooks(db));
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

        //Problem 05.
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var sb = new StringBuilder();

            var allBooksNotReleasedInGivenYear = context.Books
                .Where(x => x.ReleaseDate.HasValue && x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList();

            foreach (var book in allBooksNotReleasedInGivenYear)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 06.
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            string[] categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower())
                .ToArray();

            var booksWithGivenCategory = context.Books
                .Where(x => x.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(x => x.Title)
                .Select(x => x.Title)
                .ToList();

            foreach (var book in booksWithGivenCategory)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 07.
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var sb = new StringBuilder();

            var parsedDateTime = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            var bookTitles = context.Books
                .Where(x => x.ReleaseDate.HasValue &&
                            x.ReleaseDate.Value < parsedDateTime)
                .OrderByDescending(x => x.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();

            foreach (var book in bookTitles)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 08.
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var allAuthors = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            foreach (var author in allAuthors)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 09.
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var allBooks = context.Books
                .Where(x => EF.Functions.Like(x.Title, $"%{input}%"))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            foreach (var book in allBooks)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 10.
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var allBooks = context.Books
                .Where(x => EF.Functions.Like(x.Author.LastName, input + "%"))
                .OrderBy(x => x.BookId)
                .Select(x => $"{x.Title} ({x.Author.FirstName} {x.Author.LastName})")
                .ToList();

            foreach (var book in allBooks)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 11.
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books
                .Count(x => x.Title.Length > lengthCheck);
        }

        //Problem 12.
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var sb = new StringBuilder();

            var numberOfBooksPerAuthor = context.Authors
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    CountOfBooks = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(b => b.CountOfBooks)
                .ToList();

            foreach (var author in numberOfBooksPerAuthor)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName} - {author.CountOfBooks}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 13.
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var sb = new StringBuilder();

            var profitPerCategory = context.Categories
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks.Sum(x => x.Book.Price * x.Book.Copies)
                })
                .OrderByDescending(x => x.TotalProfit)
                .ThenBy(x => x.Name)
                .ToList();

            foreach (var category in profitPerCategory)
            {
                sb.AppendLine($"{category.Name} ${category.TotalProfit:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 14.
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var top3BooksPerCategory = context.Categories
                .Select(c => new
                {
                    c.Name,
                    TopThreeBooks = c.CategoryBooks
                        .Select(b => new
                        {
                            BookTitle = b.Book.Title,
                            BookReleaseDate = b.Book.ReleaseDate
                        })
                        .OrderByDescending(x => x.BookReleaseDate)
                        .Take(3)
                        .ToList()
                })
                .OrderBy(x => x.Name)
                .ToList();

            foreach (var category in top3BooksPerCategory)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var book in category.TopThreeBooks)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.BookReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 15.
        public static void IncreasePrices(BookShopContext context)
        {
            var bookReleasedBefore2010 = context
                .Books
                .Where(b => b.ReleaseDate.HasValue &&
                            b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in bookReleasedBefore2010)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        //Problem 16.
        public static int RemoveBooks(BookShopContext context)
        {
            var allBooksWithLessThan4200Copies = context.Books
                .Where(x => x.Copies < 4200)
                .ToList();

            foreach (var book in allBooksWithLessThan4200Copies)
            {
                var booksCategory = context.BooksCategories
                    .First(x => x.BookId == book.BookId);
                context.BooksCategories.Remove(booksCategory);
                context.Books.Remove(book);
            }

            context.SaveChanges();

            return allBooksWithLessThan4200Copies.Count;
        }
    }
}


