using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Library
    {
        public List<Book> Books { get; }
        public List<User> Users { get; }

        public Library()
        {
            Books = new List<Book>();
            Users = new List<User>();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void RegisterUser(User user)
        {
            if (!Users.Any(u => u.Name == user.Name))
                Users.Add(user);
        }

        public bool BorrowBook(string title, string userName)
        {
            var book = Books.FirstOrDefault(b => b.Title == title && b.IsAvailable);
            var user = Users.FirstOrDefault(u => u.Name == userName);

            if (book != null && user != null)
            {
                book.IsAvailable = false;
                user.BorrowedBooks.Add(book);
                return true;
            }
            return false;
        }

        public bool ReturnBook(string title, string userName)
        {
            var user = Users.FirstOrDefault(u => u.Name == userName);
            var book = user?.BorrowedBooks.FirstOrDefault(b => b.Title == title);

            if (book != null)
            {
                book.IsAvailable = true;
                user.BorrowedBooks.Remove(book);
                return true;
            }
            return false;
        }
    }
}
