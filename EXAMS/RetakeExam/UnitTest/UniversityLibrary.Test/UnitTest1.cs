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
        public void CreateBookNormaly()
        {
            TextBook textBook = new TextBook("title", "author", "category");
            Assert.AreEqual("title",textBook.Title);
            Assert.AreEqual("author", textBook.Author);
            Assert.AreEqual("category", textBook.Category);
        }
        [Test]
        public void AddToLiraryNormaly()
        {
            UniversityLibrary library = new UniversityLibrary();
            TextBook textBook = new TextBook("title", "author", "category");
            library.AddTextBookToLibrary(textBook);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Book: title - 2");
            sb.AppendLine("Category: category");
            sb.Append("Author: author");
            Assert.AreEqual(1,library.Catalogue.Count);
            Assert.AreEqual(sb.ToString(), library.AddTextBookToLibrary(textBook));
            Assert.AreEqual(2, textBook.InventoryNumber);
        }
        [Test]
        public void TryLoanExistingHolder()
        {
            UniversityLibrary library = new UniversityLibrary();
            TextBook textBook = new TextBook("title", "author", "category");
            library.AddTextBookToLibrary(textBook);
            textBook.Holder = "student";
            string result = "student still hasn't returned title!";
            Assert.AreEqual(result, library.LoanTextBook(1, "student"));
        }
        [Test]
        public void TryLoanNormaly()
        {
            UniversityLibrary library = new UniversityLibrary();
            TextBook textBook = new TextBook("title", "author", "category");
            library.AddTextBookToLibrary(textBook);
            string result = "title loaned to student.";
            Assert.AreEqual(result, library.LoanTextBook(1, "student"));
            Assert.AreEqual("student", textBook.Holder);
        }
        [Test]
        public void TryReturnNormaly()
        {
            UniversityLibrary library = new UniversityLibrary();
            TextBook textBook = new TextBook("title", "author", "category");
            library.AddTextBookToLibrary(textBook);
            textBook.Holder = "student";
            string result = "title is returned to the library.";
            Assert.AreEqual(result, library.ReturnTextBook(1));
            Assert.AreEqual("", textBook.Holder);
        }
    }
}