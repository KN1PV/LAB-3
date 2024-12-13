using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Tests
{
    public class LibraryTests
    {
        [Fact]
        public void AddBook_ShouldAddBookToLibrary()
        {
            var library = new Library();
            var book = new Book("Test Title", "Test Author");

            library.AddBook(book);

            Assert.Contains(book, library.GetBooks());
        }

        [Fact]
        public void AddBook_ThrowsException_IfDuplicateTitle()
        {
            var library = new Library();
            var book = new Book("Test Title", "Author");

            library.AddBook(book);

            Assert.Throws<InvalidOperationException>(() => library.AddBook(book));
        }

        [Fact]
        public void RemoveBook_ShouldRemoveBookByTitle()
        {
            var library = new Library();
            var book = new Book("Test Title", "Test Author");
            library.AddBook(book);

            library.RemoveBook("Test Title");

            Assert.DoesNotContain(book, library.GetBooks());
        }

        [Fact]
        public void RemoveBook_ThrowsException_IfBookNotFound()
        {
            var library = new Library();

            Assert.Throws<KeyNotFoundException>(() => library.RemoveBook("Nonexistent Title"));
        }

        [Fact]
        public void IsBookAvailable_ReturnsTrue_IfBookIsAvailable()
        {
            var library = new Library();
            var book = new Book("Available Book", "Author");
            library.AddBook(book);

            var isAvailable = library.IsBookAvailable("Available Book");

            Assert.True(isAvailable);
        }

        [Fact]
        public void IsBookAvailable_ReturnsFalse_IfBookIsUnavailable()
        {
            var library = new Library();
            var book = new Book("Unavailable Book", "Author", isAvailable: false);
            library.AddBook(book);

            var isAvailable = library.IsBookAvailable("Unavailable Book");

            Assert.False(isAvailable);
        }

        [Fact]
        public void IsBookAvailable_ReturnsFalse_IfBookDoesNotExist()
        {
            var library = new Library();

            var isAvailable = library.IsBookAvailable("Nonexistent Book");

            Assert.False(isAvailable);
        }
    }
}
