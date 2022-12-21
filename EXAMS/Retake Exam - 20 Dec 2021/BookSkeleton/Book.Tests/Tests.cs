namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        [Test]
        public void CreateBookNormaly()
        {
            Book book = new Book("book", "author");
            Assert.AreEqual(book.BookName, "book");
            Assert.AreEqual(book.Author, "author");
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CreateBookBadName(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(name, "author");
            });
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CreateBookBadAuthor(string author)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("name", author);
            });
        }
        [Test]
        public void AddFootnoteNormaly()
        {
            Book book = new Book("book", "author");
            book.AddFootnote(1, "text");
            Assert.AreEqual(1, book.FootnoteCount);
        }
        [Test]
        public void AddExistingFootnote()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Book book = new Book("name", "author");
                book.AddFootnote(1, "text");
                book.AddFootnote(1, "text");
            });
        }
        [Test]
        public void FindFootnoteNormaly()
        {
            Book book = new Book("book", "author");
            book.AddFootnote(1, "text");
            Assert.AreEqual("Footnote #1: text", book.FindFootnote(1));
        }
        [Test]
        public void FindFootnoteNotExisting()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Book book = new Book("name", "author");
                book.AddFootnote(1, "text");
                book.FindFootnote(2);
            });
        }
        [Test]
        public void AlterFootnote()
        {
            Book book = new Book("book", "author");
            book.AddFootnote(1, "text");
            book.AlterFootnote(1, "newtext");
            Assert.AreEqual("Footnote #1: newtext", book.FindFootnote(1));
        }
        [Test]
        public void AlterFootnoteNonExisting()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Book book = new Book("name", "author");
                book.AddFootnote(1, "text");
                book.AlterFootnote(2, "newtext");
            });

        }
    }
}