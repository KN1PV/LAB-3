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
        public void RegisterUser_ShouldAddUserToLibrary()
        {
            var library = new Library();
            var user = new User("John Doe");

            library.RegisterUser(user);

            Assert.Contains(user, library.Users);
        }

        [Fact]
        public void BorrowBook_ShouldAllowUserToBorrowAvailableBook()
        {

            var library = new Library();
            var user = new User("John Doe");
            library.RegisterUser(user);

            var book = new Book("Clean Code", "Robert C. Martin", true);
            library.AddBook(book);

            var result = library.BorrowBook("Clean Code", "John Doe");

            Assert.True(result);
            Assert.Contains(book, user.BorrowedBooks);
            Assert.False(book.IsAvailable);
        }

        [Fact]
        public void ReturnBook_ShouldAllowUserToReturnBorrowedBook()
        {

            var library = new Library();
            var user = new User("John Doe");
            library.RegisterUser(user);

            var book = new Book("Clean Code", "Robert C. Martin", true);
            library.AddBook(book);
            library.BorrowBook("Clean Code", "John Doe");

            var result = library.ReturnBook("Clean Code", "John Doe");

            Assert.True(result);
            Assert.DoesNotContain(book, user.BorrowedBooks);
            Assert.True(book.IsAvailable);
        }

        [Fact]
        public void BorrowBook_ShouldFailIfBookIsAlreadyBorrowed()
        {
            var library = new Library();
            var user1 = new User("John Doe");
            var user2 = new User("Jane Doe");

            library.RegisterUser(user1);
            library.RegisterUser(user2);

            var book = new Book("Clean Code", "Robert C. Martin", true);
            library.AddBook(book);

            library.BorrowBook("Clean Code", "John Doe");

            var result = library.BorrowBook("Clean Code", "Jane Doe");

            Assert.False(result);
            Assert.DoesNotContain(book, user2.BorrowedBooks);
        }

        [Fact]
        public void ReturnBook_ShouldFailIfUserDidNotBorrowBook()
        {
            var library = new Library();
            var user = new User("John Doe");
            library.RegisterUser(user);

            var book = new Book("Clean Code", "Robert C. Martin", true);
            library.AddBook(book);

            var result = library.ReturnBook("Clean Code", "John Doe");

            Assert.False(result);
            Assert.True(book.IsAvailable);
        }

        [Fact]
        public void Register_User_TracksameUser_OnlyOneUserToBeAdded()
        {
            var library = new Library();
            var user1 = new User("John Doe");
            var user2 = new User("John Doe");

            library.RegisterUser(user1);
            /*library.RegisterUser(user2);*/

            Assert.Throws<InvalidOperationException>(() => library.RegisterUser(user2));
        }

    }
}
