using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Library
    {
        private readonly Dictionary<string, Book> books = new Dictionary<string, Book>();

        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            if (books.ContainsKey(book.Title))
                throw new InvalidOperationException($"A book with the title '{book.Title}' already exists.");

            books.Add(book.Title, book);
        }

        public void RemoveBook(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty.");

            if (!books.Remove(title))
                throw new KeyNotFoundException($"No book with the title '{title}' found.");
        }

        public bool IsBookAvailable(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty.");

            return books.TryGetValue(title, out var book) && book.IsAvailable;
        }

        public IEnumerable<Book> GetBooks()
        {
            return books.Values;
        }
    }
}
