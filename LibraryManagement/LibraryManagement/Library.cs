using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Library
    {
        private List<Book> books = new List<Book>();
        private List<User> users = new List<User>();

        public void AddBook(Book book)
        {
            if (books.Any(b => b.Title == book.Title))
                throw new InvalidOperationException("Книга з такою назвою вже існує в бібліотеці.");
            books.Add(book);
        }

        public void RegisterUser(User user)
        {
            if (users.Any(u => u.Name == user.Name))
                throw new InvalidOperationException("Користувач з таким ім'ям вже зареєстрований.");
            users.Add(user);
        }

        public void BorrowBook(string title, string userName)
        {
            var book = books.FirstOrDefault(b => b.Title == title);
            if (book == null || !book.IsAvailable)
                throw new InvalidOperationException("Книга недоступна.");

            var user = users.FirstOrDefault(u => u.Name == userName);
            if (user == null)
                throw new InvalidOperationException("Користувач не знайдений.");

            book.IsAvailable = false;
            user.BorrowedBooks.Add(book);
        }

        public void ReturnBook(string title, string userName)
        {
            var user = users.FirstOrDefault(u => u.Name == userName);
            if (user == null)
                throw new InvalidOperationException("Користувач не знайдений.");

            var book = user.BorrowedBooks.FirstOrDefault(b => b.Title == title);
            if (book == null)
                throw new InvalidOperationException("Книга не була позичена цим користувачем.");

            book.IsAvailable = true;
            user.BorrowedBooks.Remove(book);
        }

        public bool IsBookAvailable(string title)
        {
            var book = books.FirstOrDefault(b => b.Title == title);
            return book?.IsAvailable ?? false;
        }
    }
}
