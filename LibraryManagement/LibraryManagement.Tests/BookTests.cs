using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Tests
{
    public class BookTests
    {
        [Fact]
        public void Book_CanBeCreated_WithValidProperties()
        {
            string title = "Test Title";
            string author = "Test Author";

            var book = new Book(title, author);

            Assert.Equal(title, book.Title);
            Assert.Equal(author, book.Author);
            Assert.True(book.IsAvailable);
        }

        [Fact]
        public void Book_Creation_ThrowsException_IfTitleIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Book("", "Author"));
        }

        [Fact]
        public void Book_Creation_ThrowsException_IfAuthorIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Book("Title", ""));
        }
    }
}
