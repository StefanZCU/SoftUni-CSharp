namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System.Text;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            TextBook textBook = new TextBook("History", "Balabanov", "Humanity");

            UniversityLibrary library = new UniversityLibrary();

            var actualResult = library.AddTextBookToLibrary(textBook);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Book: History - 1");
            sb.AppendLine($"Category: Humanity");
            sb.AppendLine($"Author: Balabanov");

            var expectedResult = sb.ToString().TrimEnd();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test2()
        {
            TextBook textBook = new TextBook("History", "Balabanov", "Humanity");
            TextBook textBook2 = new TextBook("History2", "Balabanov", "Humanity");
            TextBook textBook3 = new TextBook("History3", "Balabanov", "Humanity");

            UniversityLibrary library = new UniversityLibrary();

            library.AddTextBookToLibrary(textBook);
            library.AddTextBookToLibrary(textBook2);
            library.AddTextBookToLibrary(textBook3);

            var expectedResult = textBook3.InventoryNumber;

            Assert.AreEqual(expectedResult, 3);
        }

        [Test]
        public void Test3()
        {
            TextBook textBook = new TextBook("History", "Balabanov", "Humanity");

            UniversityLibrary library = new UniversityLibrary();

            library.AddTextBookToLibrary(textBook);

            var expectedResult = library.Catalogue.Count;

            Assert.AreEqual(expectedResult, 1);
        }


        [Test]
        public void Test4()
        {
            TextBook textBook = new TextBook("History", "Balabanov", "Humanity");
            TextBook textBook2 = new TextBook("History2", "Balabanov", "Humanity");
            TextBook textBook3 = new TextBook("History3", "Balabanov", "Humanity");

            UniversityLibrary library = new UniversityLibrary();

            library.AddTextBookToLibrary(textBook);
            library.AddTextBookToLibrary(textBook2);
            library.AddTextBookToLibrary(textBook3);

            var actualResult = library.LoanTextBook(2, "George Bush");
            var expectedResult = "History2 loaned to George Bush.";

            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(textBook2.Holder, "George Bush");
        }

        [Test]
        public void Test5()
        {
            TextBook textBook = new TextBook("History", "Balabanov", "Humanity");

            UniversityLibrary library = new UniversityLibrary();

            library.AddTextBookToLibrary(textBook);

            library.LoanTextBook(1, "George Bush");
            var actualResult = library.LoanTextBook(1, "George Bush");
            var expectedResult = "George Bush still hasn't returned History!";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test6()
        {
            TextBook textBook = new TextBook("History", "Balabanov", "Humanity");

            UniversityLibrary library = new UniversityLibrary();

            library.AddTextBookToLibrary(textBook);

            library.LoanTextBook(1, "George Bush");
            var actualResult = library.ReturnTextBook(1);
            var expectedResult = "History is returned to the library.";

            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(textBook.Holder, string.Empty);
        }
    }
}